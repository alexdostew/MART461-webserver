<?php
$host = 'localhost'; 
$db = '';
$userlogin = '';
$pass = '';
$dsn = "mysql:host=$host;dbname=$db";
$cn=new PDO($dsn, $userlogin, $pass);
?>