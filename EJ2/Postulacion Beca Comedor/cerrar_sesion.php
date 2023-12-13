
<?php
session_start();

include "conexion.inc.php";

$sql = "SELECT * FROM flujousuario ORDER BY id DESC LIMIT 1 ";
$resultado = mysqli_query($con, $sql);
$registros = mysqli_fetch_array($resultado);
if($registros!=null){
	$id = $registros["id"];

	$sql = "SELECT * FROM flujousuario ORDER BY id DESC LIMIT 1 ";
	$resultado = mysqli_query($con, $sql);
	$registros = mysqli_fetch_array($resultado);
	$id = $registros["id"];

	$fecha_fin = date("Y-m-d h:m:s");
	$sql = "UPDATE flujousuario SET fechafin = '$fecha_fin' 
	WHERE id = '$id' ";
	$resultado = mysqli_query($con, $sql);
}
session_destroy();
header("Location: index.php");
?>