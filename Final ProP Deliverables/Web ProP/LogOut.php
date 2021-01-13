<?php

if(!isset($_SESSION)){
    session_start();
}

$_SESSION['isLog']=false;
$_SESSION['isBuy']=false;
$_SESSION['initialname']="";
$_SESSION['userIDLog']="";
$_SESSION['currentEmail']="";
$_SESSION['currentKey']="";
$_SESSION['currentID']="";
header('location: index.php');
?>