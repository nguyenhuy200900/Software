<!DOCTYPE html>
<html>
<head>
        <link rel="stylesheet" type="text/css"  href="Css_Web.css"> 
        <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous"> 

        <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
        
<?php
   include("Html_Header.php")
?>
        <div class="Pages">
                <h2 class="BookingPageTitle">GA Tickets are running out!</h2><br>
                <div class="ticketsDetails">
                    <h3 id="text">Tickets</h3>
                    <p id="text">Tickets for HUSA music event 2019 are on sale now!</p><br>
                    <div class="card-group">
                            <div class="card">
                              <div class="card-body">
                                <h5 class="card-title">GA Tickets</h5><br><br><br>
                                <?php
                                if($_SESSION['isLog']==true){
                                  echo '<button class="btnGA"><a href="BookingPage2.php" class="link">General Admission</a></button> ';

                                }else{
                                  echo '<button class="btnGA"><a href="LoginPage.php" class="link">Please login to be able to purchase ticket</a></button> ';
                                  
                                }
                             ?>
                                </div>
                            </div>
                    </div>
                </div>
                <div class="prContainer">
                  <ul class="progressbar">
                      <li>choose type of tickets</li>
                      <li>information details</li>
                      <li>reserve camping spot</li>
                      <li>confirmation</li>
                  </ul>
                </div>
        </div>

        <?php
     include("Footer.php")
     ?>            
</body>          