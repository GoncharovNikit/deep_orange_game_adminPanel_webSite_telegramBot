<?php
const FILE = 'app/admin_panel.exe';

if (file_exists(FILE)) {
    header('Content-Description: File Transfer');
    header('Content-Type: application/octet-stream');
    header('Content-Disposition: attachment; filename="' . FILE . '"');
    header('Expires: 0');
    header('Cache-Control: must-revalidate');
    header('Pragma: public');
    header('Content-Length: ' . filesize(FILE));
    flush();
    readfile(FILE);
}
else {
    http_response_code(404);
}

die();
