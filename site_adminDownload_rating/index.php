<?php
// try {
    // $conn = new PDO("sqlsrv:server=tcp:deep-orange-sql-server.database.windows.net,1433;Database=game_db", "do_admin", "Orange123go");
    // $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    // $players = $conn->exec('SELECT * from Rating ORDER BY Score');
    // echo "<pre>";
    // print_r($players);
    // echo "</pre>";
// } catch (PDOException $e) {
    // print("Error connecting to SQL Server.");
    // die(print_r($e));
// }
?>
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>DeepOrange</title>
    <link rel="stylesheet" href="./style.css">
</head>

<body>
    <div class="content">
        <div class="rating">
            <ol class="rating-list">
                <li>Hello</li>
                <li>World</li>
                <li>World</li>
                <li>World</li>
                <li>World</li>
                <li>World</li>
                <li>World</li>
                <li>World</li>
                <li>World</li>
                <li>World</li>
                <li>World</li>
                <li>World</li>
                <li>World</li>
                <li>World</li>
                <li>World</li>
                <li>World</li>
                <li>World</li>
                <li>World</li>
                <li>World</li>
                <li>World</li>
                <li>World</li>
                <li>World</li>
                <li>World</li>
                <li>World</li>
                <li>World</li>
                <li>World</li>
                <li>World</li>
            </ol>
        </div>
        <div class="download">
            <div class="download-block">
                <img src="./img/download.png" id="download-img" alt="Download">
                <label for="download-img">
                    DOWNLOAD CLIENT PROGRAM TO ADD CUSTOM LISTS OF PHRASES
                </label>
            </div>
        </div>
    </div>
    <form action="download.php" method="GET" id="download-form"></form>

    <script>
        document.querySelector('.download-block').addEventListener('click', (e) => {
            document.querySelector('#download-form').submit()
        })
    </script>
</body>

</html>