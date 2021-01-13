
 <?php

 include("Html_Header.php");
?>
<?php
 $error = null;
 if(isset($_POST['submit'])){
   //Get form data
   $e =$_POST['email'];
   $p =$_POST['psw'];
   $p2 =$_POST['psw-repeat'];

   if($p2 != $p){
     $error = "<p>Your passwords are not match!</p>";
   }
   else{
     //Form is valid

     //Connect to database
     $mysqli = new MySQLi('studmysql01.fhict.local','dbi406850','namlecv0421122000','dbi406850');

     //sanitize data
     $e = $mysqli->real_escape_string($e);
     $p = $mysqli->real_escape_string($p);
     $p2 = $mysqli->real_escape_string($p2);

     //Generate verification key
     $vkey = md5(time().$e);

     //Insert to database
     
     $insert = $mysqli->query("INSERT INTO customer(`Email`, `Validation_Key`, `Password`)
     VALUES('$e','$vkey','$p')");

    if($insert){
      //Send Email
      $to = $e;
      $subject = "HUSA event Email verification";
      $message = "<a href='http://i406850.hera.fhict.nl/VerifyAccount.php?vkey=$vkey'>Register account</a>";
      $headers = "From: h.bui@student.fontys.nl \r\n";
      $headers .= "MIME-version:1.0"." \r\n";
      $headers .= "Content-type:text/html;charset=UTF-8"." \r\n";
      
      mail($to,$subject,$message,$headers);

      header('location:AfterSignUp.php');

    }else{
      echo $mysqli->error;
    }


   }
 }
?>
     <div class="Pages">
       <div>
           <span onclick="document.getElementById('id01').style.display='none'" class="close" title="Close Modal"></span>
           <form class="modal-content" action="" method="post">
             <div class="container">
               <h1>Sign Up</h1>
               <p class="loginTitle">Please fill in this form to create an account to able to purchase ticket.</p>
               <hr>
               <label for="email"><b>Email</b></label>
               <input type="text" placeholder="Enter Email" name="email" required>
         
               <label for="psw"><b>Password</b></label>
               <input type="password" placeholder="Enter Password" name="psw" required>
         

               <label for="psw-repeat"><b>Repeat Password</b></label>
               <input type="password" placeholder="Repeat Password" name="psw-repeat" required>
               
               <label>
                 <input type="checkbox" checked="checked" name="remember" style="margin-bottom:15px"> agreed to Terms & Privacy
               </label>
               <?php
                  if($error!=null)
                    echo $error;

                  $error=null;
               ?>
               <p>By creating an account you agree to our <a href="#" style="color:dodgerblue">Terms & Privacy</a>.</p>
         
               <div>
                
                 <button type="submit" name="submit" class="signupbtn" required>Sign Up</button>
               </div>
             </div>
           </form>
          
         </div>
     </div>

     <?php
     include("php/Footer.php")
     ?>   

<?php
    if(isset($_SESSION['email'])==true)
    {
        echo '<form action="AfterSignUp.php" method="post">';
        echo '</form>';
    }
    ?>
 <?php
     include("Footer.php")
     ?>     
</body>      
</html>