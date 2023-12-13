<?php
session_start();

include "conexion.inc.php";
$flujo = $_GET["flujo"];
$proceso = $_GET["proceso"];

//$_SESSION["cc"] = "NO" ;

//echo "flujo :: ".$flujo."   proceso :: ".$proceso;
 
$sql = "SELECT * FROM flujo ";
$sql .= "WHERE flujo='$flujo' and proceso = '$proceso'";
$resultado = mysqli_query($con,$sql);
$registros = mysqli_fetch_array($resultado);
$pantalla = $registros["pantalla"];
$tipo=$registros["tipo"];
$ps=$registros["procesosiguiente"];

$condicion="NO";

$sql = "SELECT * FROM flujousuario ORDER BY id DESC LIMIT 1,1 ";
//$sql .= "WHERE flujo='$flujo' and proceso = '$proceso'";
$resultado = mysqli_query($con, $sql);
$registros = mysqli_fetch_array($resultado);
if($registros!=null ){
	if($registros["fechafin"]==null){
		$id = $registros["id"];

		///count(codigo) as cont
		//SELECT LAST_INSERT_ID()
		$sql = "SELECT * FROM flujousuario ORDER BY id DESC LIMIT 1,1 ";
		//$sql .= "WHERE flujo='$flujo' and proceso = '$proceso'";
		$resultado = mysqli_query($con, $sql);
		$registros = mysqli_fetch_array($resultado);
		$id = $registros["id"];
	
		//$numerotramite=$registros["numerotramite"];
		$fecha_fin = date("Y-m-d h:m:s");
		$sql = "UPDATE flujousuario SET fechafin = '$fecha_fin' 
		WHERE id = '$id' ";
		$resultado = mysqli_query($con, $sql);
	
	}
	
	/////<input type="hidden" name="codtramite" value="<?php echo $numerotramite; 
}





?>
<html>
<head>
	<title>inscripción a materias</title>
	<link href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet">

	<style>
.alert {
  padding: 20px;
  background-color: #f44336;
  color: white;
  opacity: 1;
  transition: opacity 0.6s;
  margin-bottom: 15px;
}

.alert.success {background-color: #04AA6D;}
.alert.info {background-color: #2196F3;}
.alert.warning {background-color: #ff9800;}

.closebtn {
  margin-left: 15px;
  color: white;
  font-weight: bold;
  float: right;
  font-size: 22px;
  line-height: 20px;
  cursor: pointer;
  transition: 0.3s;
}

.closebtn:hover {
  color: black;
}
</style>
</head>
<body background="back.png">
	
	<form action="motor.php" method="GET"> 
		<?php include $pantalla.".php"; ?><br/>
		<input type="hidden" name="pantalla" value="<?php echo $pantalla; ?>">
		<input type="hidden" name="flujo" value="<?php echo $flujo; ?>">
		<input type="hidden" name="proceso" value="<?php echo $proceso; ?>">
		<input type="hidden" name="condicion" value="<?php echo $condicion="NO";; ?>">
		
		
		
		<div class="container mt-5">
			<?php 
			echo " tipo ::  ".$tipo."  porceso::  ".$proceso."  rol :: ".$_SESSION["rol"]."<br>";
			if($tipo=="C"){
				if($_SESSION["rol"]=="revisor"){
					
					echo "<input type='submit' value='NO' name='NO'>";
					echo "<input type='submit' value='SI Enviar A Entrevistador' name='SI'>";
					$_SESSION["sss"]="NO";
				}else{
					echo "<input type='submit' value='Anterior' name='Anterior'>";
					echo "<input type='submit' value='NO' name='NO'>";
					echo "<input type='submit' value='SI' name='SI'>";
				}
				
			
			}
			else{
				
				if($tipo!="I" ){
					if(!($_SESSION["rol"]=="entrevistador" && $proceso=="P6")){
						echo "<input type='submit' value='Anterior' name='Anterior'>";
					}
						
					}
				
				if(($tipo=="P"&& $ps==null)){
					echo "<h3><a href='cerrar_sesion.php'> finalizar</a>  </h3>";
				}else{

					
						echo "<input type='submit' value='Siguiente' name='Siguiente'>";
					
				}
				
			}

			?>
			
			
		</div>
	</form>
</body>
</html>
