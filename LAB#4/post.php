<?
require_once("bd_connect.php");
session_start();
if(isset($_SESSION['name'])){
    $text = $_POST['text'];
    mysql_query("INSERT INTO `answers` (`msg`,`stamp`,`datetime`,`nick`) VALUES ('".$_POST['text']."','".time()."','".date("g:i A")."','".$_SESSION['name']."')") or die(mysql_error());
    $fp = fopen("log.html", 'a');
    fwrite($fp, "<div class='msgln'>(".date("g:i A").") <b>".$_SESSION['name']."</b>: ".stripslashes(htmlspecialchars($text))."<br></div>");
    fclose($fp);
}
?>