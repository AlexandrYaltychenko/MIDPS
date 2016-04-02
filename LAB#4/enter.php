<?
require_once("bd_connect.php");
session_start();
if(isset($_SESSION['name'])){
    $text = $_POST['text'];
    if ($text == "login")
    mysql_query("INSERT INTO `online` (`nick`) VALUES ('".$_SESSION['name']."')");
else
	if ($text == "logout")
	mysql_query("DELETE from `online` WHERE `nick`='".$_SESSION['name']."'");
else {
	$result = mysql_query("SELECT * from `online`") or die(mysql_error());
$return_arr = array();
while ($row = mysql_fetch_array($result)){
	$row_array['nick'] = $row['nick'];
	array_push($return_arr,$row_array);
}

echo json_encode($return_arr);
}
}
?>