<?php
require_once("bd_connect.php");
$text = $_GET['num'];
$result = mysql_query("SELECT * from `answers`  ORDER BY id DESC LIMIT ".$_GET['num']."") or die(mysql_error());
$return_arr = array();
while ($row = mysql_fetch_array($result)){
	$row_array['msg'] = $row['msg'];
	$row_array['nick'] = $row['nick'];
	$row_array['datetime'] = $row['datetime'];
	array_push($return_arr,$row_array);
}

echo json_encode($return_arr);

?>