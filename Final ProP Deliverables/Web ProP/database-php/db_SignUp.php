<?php
$error=null;

if(!isset($_SESSION))
{
    session_start();
}
$_SESSION["email"]=$_POST["email"];
$_SESSION["p"]=$_POST["psw"];
$_SESSION["p2"]=$_POST["psw-repeat"];

   header('location:../AfterSignUp.php');


?>


