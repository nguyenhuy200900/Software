
<?php
   include("Html_Header.php")
   
?>
<?php
$error = null;

if(isset($_POST['submit'])){
  //Connect to database
  $mysqli = new MySQLi('studmysql01.fhict.local','dbi406850','namlecv0421122000','dbi406850');

  //Get form data
  $e= $_POST['email'];
  $p= $_POST['psw'];

  //Query
  $resultSet = $mysqli->query("Select * From customer
                               Where Email = '$e' and Password = '$p' ");

  if($resultSet->num_rows != 0){
    //Proccess Login
      $row = $resultSet->fetch_assoc();
      $verified = $row["Verified"];
      $vkey = $row["Validation_Key"];
      $fname = $row["Fname"];
      $customerID = $row["customerId"];
      
      if($verified == 1){
        //continue proccess
        if($fname != ""){
        $_SESSION['isBuy']=true; 
        }else{
          $_SESSION['isBuy']=false;
        }  
        $_SESSION['isLog']=true;
        $_SESSION['currentEmail']=$e;
        $_SESSION['currentKey'] = $vkey;
        $_SESSION['currentID'] = $customerID;

        header('location:index.php');
        
      }else{
        $error = "<p>This account has not been verified!</p>";
      }
  }else{
    //Invalid 
    $error = "<p> The email or password you entered is incorrect!</p>";
  }
}
?>
    <div class="Pages">
            <span onclick="document.getElementById('id01').style.display='none'" class="close" title="Close Modal"></span>
            <form class="modal-content" action="" method="post">
              <div class="container">
                <h1 class="loginTitle">Login</h1>
                <p class="loginTitle">Please fill in your account information.</p>
                <hr>
                <br>
                <label for="email"><b>Email</b></label><br>
                <input type="text" placeholder="Enter Email" name="email" required class="emailPass"><br><br>
          
                <label for="psw"><b>Password</b></label><br>
                <input type="password" placeholder="Enter Password" name="psw" required class="emailPass"><br><br>
           
                <label>
                  <input type="checkbox" checked="checked" name="remember" style="margin-bottom:15px"> Remember me
                </label><br>
                <?php
                  if($error!=null)
                    echo $error;

                  $error=null;
               ?>
                <div>
                 
                  <button name="submit" type="submit" class="signupbtn">Log in</button>
                </div>
              </div>
            </form>
            <br><br><br>
            <p class="extra">Do not have a account? <a href="SignUpPage.php">Sign up now!</a></p>
            <p class="extra"> Test ticket sample, will delete <a href="ticketSample.php">Sign up now!</a></p>
     </div>   
     <?php
     include("Footer.php")
     ?>       
</body>

</html>