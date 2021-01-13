<!DOCTYPE html>
<html>

<?php
   
   $mysqli = new MySQLi('studmysql01.fhict.local','dbi406850','namlecv0421122000','dbi406850');

    $getAllSpot = $mysqli->query("Select * From camping_spot");
                    
?>
<?php

if(!isset($_SESSION)){
      session_start();
  }
  
?>
<!DOCTYPE html>
<head>
        <link rel="stylesheet" type="text/css"  href="Css_Web.css">
        <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
        <link rel="stylesheet" href="reboot.scss">

      <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>


        <!-- <meta name="viewport" content="width=device-width, initial-scale=1"> -->
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

    <br> <br>
    <div class="container mt-5 pt-5">
        <div class="row">
        <h1 class="reservees" style="color:wheat">Reserve camping spot</h1><br><br><br>
        <h2 class="reservee" style="color:wheat">You can reserve a spot for you which up to 5 people per spot, 
the available spot are shown by buttons below</h2>
<br><br><br><br>
        <img src="image/Map.png" class="img-fluid">
        </div>
        
        <div class="row">
            <div class="col-md-100" style="color:white">
                <h3 class="ZoneA">Zone A</h3>
                
                <div class="rowbtns">
                    
                    <?php
                    $currentKey = $_SESSION['currentKey'];
                     if($getAllSpot->num_rows != 0){
                        
                        foreach($getAllSpot as $spot){
                            
                            $id = $spot['spotId'];

                            $vkey = $spot['Validation_Key'];
                            
                            
                            $isReserved = $spot['isReserved'];
                    
                            
                            if($isReserved=='0')
                            {  
                                echo "<div class='m-1'>";
                                echo '<a href="http://i406850.hera.fhict.nl/AfterReserve.php?id='.$id.'" class="btn btn-primary">'.$id.'</a>';
                                echo "</div>";
                            }
                            if($isReserved=='1'&& $vkey!=$currentKey)
                            {
                                echo "<div class='m-1'>";
                                echo '<a href="#" style="pointer-events: none;" class="btn btn-secondary">'.$id.'</a>';
                                echo "</div>";
                            }
                            if($isReserved=='1'&& $vkey == $currentKey)
                            {
                                echo "<div class='m-1'>";
                                echo '<a href="#" style="pointer-events: none;" class="btn btn-success">'.$id.'</a>';
                                echo "</div>";
                            }
                        
                        }   
                    
                    }else{
                    
                    }   
                    ?>
                </div>
            </div>
            
            
                
        </div>
        <br>
        <br><br><br>
        
    </div>  
    <?php
     include("Footer.php")
     ?>   
</body>      