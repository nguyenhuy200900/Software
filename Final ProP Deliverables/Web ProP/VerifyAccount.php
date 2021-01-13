<?php
include("Html_Header.php");

if(isset($_GET['vkey'])){
    //Process verification
    $vkey = $_GET['vkey'];

    $mysqli = new MySQLi('studmysql01.fhict.local','dbi406850','namlecv0421122000','dbi406850');

    $resultSet = $mysqli->query("Select Validation_Key,Verified From customer 
                                 Where Verified = 0 and Validation_Key = '$vkey' Limit 1");

    if($resultSet->num_rows == 1){
        //Validate email
        $update = $mysqli->query("Update customer set Verified = 1
                                  Where Validation_Key = '$vkey' LIMIT 1");
        if($update){
            echo "<div ><h2 style='color:white;margin-top:10%;margin-left:5%'>
            Your account has been verified. You may now login.</h2></div>";
        }else{
            echo $mysqli->error;
        }
    }else{
        echo "<div ><h2 style='color:white;margin-top:10%;margin-left:5%'>
        This email is invalid or already be verified</h2></div>"; 
    }
}else{
    die("Something went wrong");
}
    
   

?>
</body>
</html>