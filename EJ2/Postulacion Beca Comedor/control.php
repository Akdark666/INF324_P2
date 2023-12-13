<?php 
$usuario = $_GET["usuario"];
$password = $_GET["password"];

session_start();

include "conexion.inc.php";

$sql="SELECT count(*) AS contador, rol,ci FROM bdcomedor.usuario ";
$sql.="where nombre='$usuario'&& ci='$password' GROUP BY nombre";
$resultado=mysqli_query($con, $sql);
$registros=mysqli_fetch_array($resultado);
$contador=$registros["contador"];
$ci=$registros["ci"];
$rol=$registros["rol"];



if (($contador>0) && ($password==$ci) && $rol=="estudiante")
{
	$_SESSION["usuario"] = $usuario;
	$_SESSION["rol"] = $registros["rol"];
	
	

	$flujo = 'F1';
	$proceso = 'P1';

	$sql = "SELECT COALESCE(max(numerotramite), 0) + 1 AS numerotramite FROM flujousuario";
	$resultado = mysqli_query($con, $sql);
	$registros = mysqli_fetch_array($resultado);
	$numerotramite = $registros["numerotramite"];

	if($numerotramite==1){
		$numerotramite=111;
	}
	if (!empty($proceso)) {
		$fecha_fin = "NULL";
		$sql = "INSERT INTO flujousuario(numerotramite, flujo, proceso, fechainicio, fechafin, usuario)
				VALUES ('".$numerotramite."','".$flujo."','$proceso','".date("Y-m-d h:m:s")."' ";
		$sql .= ",NULL,'".$_SESSION["usuario"]."')";
		$resultado = mysqli_query($con, $sql);
	}
	
	header("Location: mflujo.php?flujo=$flujo&proceso=$proceso");
} 
else {

	if (($contador>0) && ($password==$ci) && $rol=="revisor")
	{

		$_SESSION["usuario"] = $usuario;
	$_SESSION["rol"] = $registros["rol"];
	$_SESSION["sss"] = "NO";

	$flujo = 'F2';
	$proceso = 'P4';

	$sql = "SELECT COALESCE(max(numerotramite), 0) + 1 AS numerotramite FROM flujousuario";
	$resultado = mysqli_query($con, $sql);
	$registros = mysqli_fetch_array($resultado);
	$numerotramite = $registros["numerotramite"];

	if($numerotramite==1){
		$numerotramite=111;
	}
	if (!empty($proceso)) {
		$fecha_fin = "NULL";
		$sql = "INSERT INTO flujousuario(numerotramite, flujo, proceso, fechainicio, fechafin, usuario)
				VALUES ('".$numerotramite."','".$flujo."','$proceso','".date("Y-m-d h:m:s")."' ";
		$sql .= ",NULL,'".$_SESSION["usuario"]."')";
		$resultado = mysqli_query($con, $sql);
	}
	
	header("Location: mflujo.php?flujo=$flujo&proceso=$proceso");
	}
	elseif (($contador>0) && ($password==$ci) && $rol=="entrevistador")
	{
		$_SESSION["usuario"] = $usuario;
	$_SESSION["rol"] = $registros["rol"];

	$flujo = 'F3';
	$proceso = 'P6';

	$sql = "SELECT COALESCE(max(numerotramite), 0) + 1 AS numerotramite FROM flujousuario";
	$resultado = mysqli_query($con, $sql);
	$registros = mysqli_fetch_array($resultado);
	$numerotramite = $registros["numerotramite"];

	if($numerotramite==1){
		$numerotramite=111;
	}
	if (!empty($proceso)) {
		$fecha_fin = "NULL";
		$sql = "INSERT INTO flujousuario(numerotramite, flujo, proceso, fechainicio, fechafin, usuario)
				VALUES ('".$numerotramite."','".$flujo."','$proceso','".date("Y-m-d h:m:s")."' ";
		$sql .= ",NULL,'".$_SESSION["usuario"]."')";
		$resultado = mysqli_query($con, $sql);
	}
	
	header("Location: mflujo.php?flujo=$flujo&proceso=$proceso");
	}else{
		header("Location: index.php");
	}


	
}
