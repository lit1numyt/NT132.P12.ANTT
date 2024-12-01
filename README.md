# Setup HAproxy và Keepalived
## Cài đặt
```
sudo apt-get update
sudo apt-get install apache2 
sudo apt-get keepalived 
sudo apt-get install haproxy
```

kiểm tra
```
apache2 --v
haproxy --v
keepalived --v
```

## Host 2 trang note


## Setup Keepalived
để setup thì ta tiến hành thực hiện tất cả các bước này trên 2 máy, ngoại trừ bước config thì 2 máy sẽ có 2 script riêng (phân biệt máy MASTER và BACKUP)
### Bước 1
Thêm dòng sau
```
net.ipv4.ip_nonlocal_bind=1
```
vào file /etc/sysctl.conf
thực hiện restart server để chạy config vừa sửa
```
sudo sysctl -p
```
### Bước 2
tạo file config Keepalived
```
sudo nano /etc/keepalived/keepalived.conf
```
điền nội dung sau vào file máy 1 (master)
```
global_defs {
  router_id test1                            #khai báo route_id của keepalived
}
vrrp_script chk_haproxy {
  script "killall -0 haproxy"
  interval 2
  weight 2
}
vrrp_instance VI_1 {
  virtual_router_id 51
  advert_int 1
  priority 100
  state MASTER
  interface ens33                            #thông tin tên interface của server, bạn dùng lệnh `ifconfig` để xem và điền cho đúng
  virtual_ipaddress {
    172.17.3.222 dev ens33           #Khai báo Virtual IP cho interface tương ứng
  }
 authentication {
     auth_type PASS
     auth_pass 123456                    #Password này phải khai báo giống nhau giữa các server keepalived
     }
  track_script {
    chk_haproxy
  }
}
```
điền nội dung sau vào máy 2 (backup)
```
global_defs {
  router_id test2
}
vrrp_script chk_haproxy {
  script "killall -0 haproxy"
  interval 2
  weight 2
}
vrrp_instance VI_1 {
  virtual_router_id 51
  advert_int 1
  priority 99
  state BACKUP
  interface ens33
  virtual_ipaddress {
    172.17.3.222 dev ens33
  }
authentication {
        auth_type PASS
        auth_pass 123456
        }
track_script {
    chk_haproxy
    }
  }

```
sau khi khai báo ở cả 2 máy thì chạy lệnh
```
sudo service keepalived start
```
ta có thể kiểm tra bằng 
```
ip addr sh
```
## Setup HAproxy
tiến hành tạo file config 
```
sudo nano /etc/haproxy/haproxy.cfg
```
điền nội dung
```
global
        daemon
        maxconn 256

    defaults
        mode http
        timeout connect 5000ms
        timeout client 50000ms
        timeout server 50000ms

    frontend http-in
        bind *:80
        default_backend app
    backend static
        balance roundrobin
        server static [ip]:[port]
    backend app
        balance roundrobin
        server test1 [ip máy 1]:[port máy 1] check
        server test2 [ip máy 2]:[port máy 2] check
```

