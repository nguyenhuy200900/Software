
<?php

if(!isset($_SESSION)){
      session_start();
  }
  
?>
<!DOCTYPE html>
<head>
        <link rel="stylesheet" type="text/css"  href="Css_Web.css">
      <!--  <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
      <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>


        <meta name="viewport" content="width=device-width, initial-scale=1">-->
    <!-- <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script> -->
        
</head>
<body style="background-color:black">
      <div class="header mb-5">
            <img src ="../image/Logo1.png" class="logo">
       <ul>
           <li class="navi"><a href="index.php"><p>Home</p></a></li>
           <li class="navi"><a href="Artist.php"><p>Artists</p></a></li>
           <li class="navi"><a href="BookingPage.php"><p>Booking</p></a></li>
           <?php
                  if($_SESSION['isBuy']==true){
                        echo '<li class="navi"><a href="ReserveCampPage.php"><p>Camping</p></a></li>';
                  }
           ?>
           <li class="navi"><a href="ContactPage.php"><p>Contact</p></a></li>
       </ul>
       <ul>
             <?php
             if($_SESSION['isLog']==true){
                
                  echo'<li class="lgsu"><a href="LogOut.php"><p >Logout</p></a></li>';
      
             }else{
                  echo'<li class="lgsu"><a href="LoginPage.php"><p >Login</p></a></li>';
                  echo'<li class="lgsu"><a href="SignUpPage.php"><p >Sign Up</p></a></li>';
             }
             
             ?>
       </ul>
      </div>
