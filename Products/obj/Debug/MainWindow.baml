   M S B A M L   `   `   `  ????C  ?Products, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ProductsProducts  5   	       Products.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Products     5   	     ? Title$  Авторизация??5   	   $	??450??6   $	??800??6*    ? WindowStartupLocation$ CenterScreen=?66   .??5	      ? ???	#FFEAEAEA ? RowDefinitions 5
   
   ?? 5      ?? 5      ?? 5      ?? 5      ?? 5       ? ColumnDefinitions 5   
   ?? 5      ?? 5      ?? 5      .+?5   
   ?? $??Center=?6   $??Microsoft JhengHei Light)?6+   $??Center=?6Q   $??3??6n   $??36(?6?   .??6?   " Добро пожаловать!6?   ?? 5   
   $??1??6   $??Right=?6   $??Center=?69   $??0,0,10,0q?6T   $??18(?6f   .??6t   Логин:6|   ?? 5   
   $??2??6   $??Right=?6   $??Center=?69   $??0,0,10,0q?6T   $??18(?6f   .??6t   Пароль:6}   ?? 5   
   -   5         ??Name$ 	loginText??5      $??1??6%   $??18(?62   $??1??6@   $??Center=?6P   G? 5   
   -   5         G?Name$ passwordText??5      $??18(?6,   $??2??6:   $??1??6G   $??Center=?6W   6t   ?? 5   
   -   5         ??Name$ loginB??5      $??Center=?6!   $??Center=?6>   $??18(?6Y   $	??150??6g   $??10q?6v   $??1??6?   $??3??6?   $??
Войти??6?   6?   ?? 5   
   $??0,10,0,0q?6   $??1??6"   64   5      5      