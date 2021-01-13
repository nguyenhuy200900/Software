<?php
if(!isset($_SESSION))
{
    session_start();
}
 $dbhost = "studmysql01.fhict.local ";
 $dbuser = "dbi406850";
 $dbpass = "namlecv0421122000";
 $db = "dbi406850";
 $conn = new mysqli($dbhost, $dbuser, $dbpass,$db) or die("Connect failed: %s\n". $conn -> error);

 function runSQL($sql){
    if ($conn->query($sql) === TRUE) {
        $insert_sql = $conn->insert_sql;
       return true;
    } else {
        echo "Error: " . $sql . "<br>" . $conn->error;
        return false;
    }
    
 }
 
?>