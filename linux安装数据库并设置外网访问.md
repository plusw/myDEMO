### debian10安装mysql  Server version: 10.3.36-MariaDB-0+deb10u2 Debian 10
wget https://dev.mysql.com/get/mysql-apt-config_0.8.22-1_all.deb   

dpkg -i mysql-apt-config_0.8.22-1_all.deb     

apt install mariadb-server mariadb-client   

安装完成
### 修改配置,外网访问
修改host
```
update user set host = '%' where user ='root';   
```
设置授权任何主机都可以登录
```
GRANT ALL PRIVILEGES ON *.* TO 'root'@'%' WITH GRANT OPTION;   
```
刷新修改
```
FLUSH PRIVILEGES;    
```
重启mysql      

service mysql restart    

修改配置文件   
vim /etc/mysql/mariadb.conf.d/50-server.cnf   
  
修改为  bind-address = 0.0.0.0   

设置mysql密码，有密码才可以进行远程访问   

update mysql.user set authentication_string=password('root') where user='root';   

service mysql restart   

