<?php 

$connect = new PDO("mysql:host=localhost", "root", "");

function PDO_query($sql, $array)
{
    $stmt = $connect->prepare($sql);
    if(!$stmt)
    {
        return $stmt->execute($array);
    }
    else
    {
        return $stmt->errorInfo()[1];
    }
}

function pdo_fetchAll($stmt)
{
    $stmt->fechAll();
}
?>