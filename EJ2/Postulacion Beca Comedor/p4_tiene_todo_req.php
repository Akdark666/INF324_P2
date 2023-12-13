<div class="panel-heading">                  
<h1> Bienvenido  <?php 

echo  $_SESSION["rol"]." : ".$_SESSION["usuario"];//$_SESSION["rol"]."  ". ?>
                            <h3><a href="cerrar_sesion.php">LOGOUT</a>  </h3>
                        </div>

                        <div class="panel-heading">            
                        <?php
 
  if($_SESSION["rol"]=="revisor"){
    if ($_SESSION["sss"]=="SI") {
     
    echo "  <span class='closebtn'>&times;</span>    <strong>Documentos enviados al entrevistador!</strong> Se ha enviado los  documentos para su entrevista.</div> <div class='alert info'>";
  }
 }
?> 
 </div>
<div class="container mt-5">
  <div class="card bg-light border-0 p-0 mx-auto" style="max-width: 400;">
     
    <h1 class="text-primary mb-12">¿CUMPLE LOS REQUISITOS?</h1>

</div>
</div>
<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
