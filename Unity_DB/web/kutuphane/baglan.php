<?php
ob_start();
session_start();
error_reporting(0);

$serverip = "127.0.0.1";
$username = "root";
$password = "";
$dbname = "unity_oyun";

try{
    $db = new PDO("mysql:host=$serverip;dbname=$dbname;charset=utf8", $username, $password);
}catch ( PDOException $e ){
    print $e->getMessage();
}

?>