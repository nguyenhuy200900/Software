        <?php
        include("Html_Header.php")
        ?>
    <div class="Pages">
      <h1>  WELCOME TO HUSA MUSIC EVENT   </h1>
      <video autoplay="autoplay" class="video" muted loop >
            <source src="image/video/Home_Video.mp4" type="video/mp4">
      </video>
      <br> <br> <br>
      <div class="slideshow-container">

            <div class="mySlides">
              <div class="numbertext">1 / 3</div>
              <img src="image/image1.jpg" style="width:100%">
              <div class="text">Let's enjoy the most interesting music event</div>
            </div>
            
            <div class="mySlides">
              <div class="numbertext">2 / 3</div>
              <img src="image/image2.jpeg" style="width:100%">
              <div class="text">Are you READY???</div>
            </div>
            
            <div class="mySlides">
              <div class="numbertext">3 / 3</div>
              <img src="image/image3.jpg" style="width:100%">
              <div class="text">Click the button below and Let the music take control</div>
            </div>
            
            <a class="prev" onclick="plusSlides(-1)">&#10094;</a>
            <a class="next" onclick="plusSlides(1)">&#10095;</a>
            
      </div>
            <br> <br>
            
            <div style="text-align:center">
              <span class="dot" onclick="currentSlide(1)"></span> 
              <span class="dot" onclick="currentSlide(2)"></span> 
              <span class="dot" onclick="currentSlide(3)"></span> 
            </div>  

            <script>
                    var slideIndex = 1;
                    showSlides(slideIndex);
                    
                    function plusSlides(n) {
                      showSlides(slideIndex += n);
                    }
                    
                    function currentSlide(n) {
                      showSlides(slideIndex = n);
                    }
                    
                    function showSlides(n) {
                      var i;
                      var slides = document.getElementsByClassName("mySlides");
                      var dots = document.getElementsByClassName("dot");
                      if (n > slides.length) {slideIndex = 1}    
                      if (n < 1) {slideIndex = slides.length}
                      for (i = 0; i < slides.length; i++) {
                          slides[i].style.display = "none";  
                      }
                      for (i = 0; i < dots.length; i++) {
                          dots[i].className = dots[i].className.replace(" active", "");
                      }
                      slides[slideIndex-1].style.display = "block";  
                      dots[slideIndex-1].className += " active";
                    }
                    </script>
                    <br><br><br>
        <button class="moreInfo"> More information  </button>     
     </div>   
     <?php
     include("Footer.php")
     ?>    
</body>

</html>