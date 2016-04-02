<?php
header('Content-type: text/html; charset=utf-8');
$db_host = 'localhost';
$db_name = 'midps';
$db_username = 'tester';
$db_password = '12345678';
$connect_to_db = mysql_connect($db_host, $db_username, $db_password) or die("Could not connect: " . mysql_error());
mysql_select_db($db_name, $connect_to_db) or die("Could not select DB: " . mysql_error());
mysql_query("set names utf8");
date_default_timezone_set('Europe/Chisinau');
?>