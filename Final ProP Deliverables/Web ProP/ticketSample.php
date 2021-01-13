<?php
if(!isset($_SESSION)){
    session_start();
}
if(isset($_GET['vkey'])){
    //Process verification
    $vkey = $_GET['vkey'];
    
    $mysqli = new MySQLi('studmysql01.fhict.local','dbi406850','namlecv0421122000','dbi406850');

    $getEmail = $mysqli->query("Select * From customer
                                Where Verified = 1 and Validation_Key = '$vkey'");
    if($getEmail->num_rows ==1){
        $row = $getEmail->fetch_assoc();
        $fn = $row["Fname"];
        $ln = $row["Lname"];
    }else{
        $fn = "unknown";
        $ln = "";
    }
}
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Document</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
</head>
<body>
    <div class="container col-5 m-5">
        <div class="card">
        <div class="row m-5">
            <div class="col-12 my-3">
                <h1>HUSA'S MUSIC FESTIVAL 2019</h1>
            </div>
            <div class="col-5 mt-4">
            <img src="image/Logo1.png" width="100%" height="100%" class="img-thumbnail">
            </div>
            <div class="col-7 mt-4">
                <?php
                
                $barcode_link="http://www.barcodes4.me/barcode/c128b/".$vkey.".jpg";
                echo "<h5 class='ml-5 pl-3'>Visitor: ".$fn." ".$ln."</h5>";
                echo "<img src='".$barcode_link."' class='rounded float-left' >";
                ?>
                
            </div>
        </div>
        

        </div>
    </div>
</body>
</html>