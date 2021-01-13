<?php
   include("Html_Header.php")
?>
<?php
 $error = null;
 if(isset($_POST['submit'])){
   //Get form data

$fn= $_POST['fname'];
$ln= $_POST['lname'];
$noTicket = $_POST['nrOfTickets'];
$iban = $_POST['iban'];
$email = $_SESSION['currentEmail'];
$vkey = $_SESSION['currentKey'];

$mysqli = new MySQLi('studmysql01.fhict.local','dbi406850','namlecv0421122000','dbi406850');

//Query

//update user info
$update = $mysqli->query("Update customer set Fname = '$fn', Lname = '$ln', IBAN = '$iban'
                          Where Email = '$email' ");

//insert customer base on number of ticket
for( $i = 0; $i < $noTicket-1; $i++){
  $insert = $mysqli->query("INSERT INTO customer( `Validation_Key`)
                            VALUES('$vkey') ");
}

if($update && $insert){
  //Send Email with ticket
  $to = $email;
  $subject = "E-Ticket HUSA music event";

  $message = "<h2>Thank you for purchase $noTicket ticket(s) to our HUSA event, Here is the link to your pdf ticket</h2>
              <br><br><br>
              <a href='http://i406850.hera.fhict.nl/ticketSample.php?vkey=$vkey'>PDF Ticket link</a>";
  $headers = "From: h.bui@student.fontys.nl \r\n";
  $headers .= "MIME-version:1.0"." \r\n";
  $headers .= "Content-type:text/html;charset=UTF-8"." \r\n";
  
  mail($to,$subject,$message,$headers);

  $_SESSION['isBuy']=true;
  header('location:BookingPage4.php');

}else{
  echo $mysqli->error;
}


 }
?>
        <div class="PersonalDetailsPage">
        <form class="modal-content" action="" method="POST">
            
              <h1 class="personalTitle">Personal Details</h1>
              <hr>
              <br>
              <div class="informationForm" style="height:630px; overflow-x:hidden;">
              <h3 class="nrPerson">First Person:</h3>  
              <hr class="hrr"> 
              
        
              <label for="fName" class="labelEmailFLName"><b>First Name</b></label><br>
              <input type="text" placeholder="Enter First Name" name="fname" required class="emailPass"><br>

              <label for="lName" class="labelEmailFLName"><b>Last Name</b></label><br>
              <input type="text" placeholder="Enter Last Name" name="lname" required class="emailPass"><br>

              <label for="BDay" class="labelEmailFLName"><b>Birthday</b></label><br>
              <input type="date" name="dob" required class="emailPass"><br>

              <label for="nrOfTickets" class="labelEmailFLName"><b>Number of tickets</b></label><br>
              <select name="nrOfTickets">
                <option value="1" selected>1</option>
                <option value="2">2</option>
                <option value="3">3</option>
                <option value="4">4</option>
                <option value="5">5</option>
                <option value="6">6</option>
                <option value="7">7</option>
              </select>
        
              <label for="IBAN" class="labelEmailFLName"><b>IBAN</b></label><br>
              <input type="text" placeholder="Enter IBAN number" name="iban" required class="emailPass"><br>
              
              
              <hr class="hrrend">
              
              <button class="btnSubmit" name="submit" type="submit">Submit</button> 
            </div>
          </form><br><br>
          
          <div class="prContainer">
                <ul class="progressbar">
                    <li class="active">choose type of tickets</li>
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