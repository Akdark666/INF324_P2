<?php
include "conexion.inc.php";
session_start();
$flujo = $_GET["flujo"];
$proceso = $_GET["proceso"];

$pantalla = $_GET["pantalla"];
$tramite = $_SESSION["codtramite"];
$usuario = $_SESSION["usuario"];
$_SESSION["sss"] = $_GET["condicion"];
if (empty($proceso)) {
    echo "Su flujo termino";
    exit();
}


$condi = "SELECT * FROM flujo ";
$condi .= "WHERE flujo='$flujo' and proceso='$proceso' ";
$result = mysqli_query($con, $condi);
$regist = mysqli_fetch_array($result);
$tipo = $regist["tipo"];
$procesoSiguiente = $regist["procesosiguiente"];

//$rol = $regist["rol"];
//$ps="";



// condicional
if ($tipo == 'C') {

    $sql="SELECT * FROM flujocondicional ";
    $sql.="WHERE codFlujo='$flujo' and codProceso='$proceso'";
    $resultado = mysqli_query($con, $sql);
    $registros = mysqli_fetch_array($resultado);

    $procesoSi = $registros["codProcesoSi"];
    $procesoNo = $registros["codProcesoNo"];

    //$random = rand(0, 1);
    if (isset($_GET["Anterior"]))
    {
        $sql="SELECT  count(*) AS contador FROM flujo ";
        $sql.="WHERE flujo='$flujo' and procesosiguiente='$proceso'";
        $resultado = mysqli_query($con, $sql);
        $registros = mysqli_fetch_array($resultado);
        //$procesoSiguiente = $registros["proceso"];
        //$tipo = $registros["tipo"];
        $contador=$registros["contador"];

        if ($contador>0){
        $sql="SELECT  * FROM flujo ";
        $sql.="WHERE flujo='$flujo' and procesosiguiente='$proceso'";
        $resultado = mysqli_query($con, $sql);
        $registros = mysqli_fetch_array($resultado);
        $procesoSiguiente = $registros["proceso"];
        $tipo = $registros["tipo"];
        }
    }
    else{
        if (isset($_GET["SI"])) {
            if($_SESSION["rol"]=="revisor"){
                $_SESSION["sss"] = "SI";
                header("Location: mflujo.php?flujo=$flujo&proceso=$proceso");
            }else{
                if($_SESSION["rol"]=="entrevistador" || $_SESSION["rol"]=="estudiante"){
                    $procesoSiguiente = $procesoSi;
                }else{

                    $_SESSION["sss"] = "NO";
                    $procesoSiguiente = $proceso;
                }
                
            }
            
        } else {
            $_SESSION["sss"] = "NO";
            $procesoSiguiente = $procesoNo;
        }
    }
    
    
} else {
    if (isset($_GET["Anterior"]))
    {
        //echo ("flujo:**: ".$flujo."   pro: ***  ".$proceso) ;

        $sql="SELECT  count(*) AS contador FROM flujo ";
        $sql.="WHERE flujo='$flujo' and procesosiguiente='$proceso'";
        $resultado = mysqli_query($con, $sql);
        $registros = mysqli_fetch_array($resultado);
        //$procesoSiguiente = $registros["proceso"];
        //$tipo = $registros["tipo"];
        $contador=$registros["contador"];

        if ($contador>0){
        $sql="SELECT  * FROM flujo ";
        $sql.="WHERE flujo='$flujo' and procesosiguiente='$proceso'";
        $resultado = mysqli_query($con, $sql);
        $registros = mysqli_fetch_array($resultado);
        $procesoSiguiente = $registros["proceso"];
        $tipo = $registros["tipo"];
        }
        else{
            $sql="SELECT  count(*) AS contador FROM flujocondicional  ";
            $sql.="WHERE codFlujo='$flujo' and codProcesoSi like '$proceso'";
            $resultado = mysqli_query($con, $sql);
            $registros = mysqli_fetch_array($resultado);
            $contador=$registros["contador"];
            if ($contador>0){
                $sql="SELECT * FROM flujocondicional ";
                $sql.="WHERE codFlujo='$flujo' and codProcesoSi like '$proceso'";
                $resultado = mysqli_query($con, $sql);
                $registros = mysqli_fetch_array($resultado);
                
               // $procesoNo = $registros["codProcesoNo"];
                $procesoSiguiente = $registros["codProceso"];;
               // $procesoSiguiente = $proceso;
            }else{
                $sql="SELECT * FROM flujocondicional ";
                $sql.="WHERE codFlujo='$flujo' and codProcesoNo='$proceso'";
                $resultado = mysqli_query($con, $sql);
                $registros = mysqli_fetch_array($resultado);
                
               // $procesoNo = $registros["codProcesoNo"];
                $procesoSiguiente = $registros["codProceso"];
            }

            
        }
   
       
        
    }

 
}
 ///if (isset($_GET["Siguiente"])) {

    $fecha_fin = date("Y-m-d h:m:s");
$sql = "UPDATE flujousuario SET fechafin = '$fecha_fin' 
WHERE numerotramite = '$tramite' AND proceso = '$proceso'";
$resultado = mysqli_query($con, $sql);

$sql = "SELECT COALESCE(max(numerotramite), 0) + 1 AS numerotramite FROM flujousuario";
$resultado = mysqli_query($con, $sql);
$registros = mysqli_fetch_array($resultado);
$numerotramite = $registros["numerotramite"];

if (!empty($procesoSiguiente)) {
    $fecha_fin = "NULL";
    $sql = "INSERT INTO flujousuario(numerotramite, flujo, proceso, fechainicio, fechafin, usuario)
             VALUES ('".$numerotramite."','".$flujo."','$procesoSiguiente','".date("Y-m-d h:m:s")."' ";
    $sql .= ",NULL,'".$_SESSION["usuario"]."')";
    $resultado = mysqli_query($con, $sql);
}

if(!($_SESSION["rol"]=="revisor" && isset($_GET["SI"]))){
    header("Location: mflujo.php?flujo=$flujo&proceso=$procesoSiguiente");
}
    //include "guardar_actividad_usuario.inc.php";


?>
