<?php
include("Html_Header.php");
if(isset($_GET['id'])){
    //Process verification
    $id = $_GET['id'];
    $currentKey = $_SESSION['currentKey'];
    
    $mysqli = new MySQLi('studmysql01.fhict.local','dbi406850','namlecv0421122000','dbi406850');

    $updateCamp = $mysqli->query("Update camping_spot Set isReserved = 1, Validation_Key = '$currentKey' Where spotId = '$id'");

    
    echo '<div ><h2 style="color:white;margin-top:10%;margin-left:5%"> Thank you for reserve camp number '.$id.'.</h2></div>';
    echo '<div><h2 style="color:white;margin-top:10%;margin-left:5%"> Enjoy your wonderful days at our event </h2></div>';   
}
include("Footer.php")
?>   
</body>