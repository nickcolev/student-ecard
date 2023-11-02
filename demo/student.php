<?php
function err_response($msg) {
	header('Content-Type: text/plain');
	echo $msg;
	exit(1);
}

	if(!$_SERVER['QUERY_STRING']) err_response('usage: ?n');
	$a = file('student.csv');
	$r = $a[$_SERVER['QUERY_STRING'] - 1];
	if(!$r) err_response('out of range');
	$ar = preg_split('/,/',$r);
	/*
	echo '<pre>';
	echo $_SERVER['QUERY_STRING']."\n";
	print_r($a);
	echo $r;
	print_r($ar);
	echo '</pre>';
	*/
	echo <<<HTM
<html><head><title>Student e-card</title>
<meta name="viewport" content="width=device-width,initial-scale=1.25" />
<style>
body { font-family: sans-serif; }
table { padding-top: 3em; }
td { font-size: 2em; }
</style>
</head>
<body>

<center>
<h1>ПГМЕТТ „Христо Ботев“, Шумен<hr></h1>
<table>
 <tr><td width="260"><img src="${ar[1]}.png"/></td><td>${ar[0]}, ${ar[2]}</td></tr>
</table>
</center>

</body></html>
HTM;
?>
