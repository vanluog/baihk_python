$(document).ready(function () {
    $.post("api.aspx", {
        action: "GetTopTracks"
    }, function (data) {
        // Xử lý dữ liệu JSON nhận được
        console.log(data); // Ví dụ: in ra console

        // Chuyển đổi dữ liệu JSON thành mảng các đối tượng
        var topTracks = JSON.parse(data);

        // Tạo bảng HTML
        var tableHtml = `
            <table>
                <thead>
                    <tr>
                        <th>Rank</th>
                        <th>Name</th>
                        <th>Artist</th>
                        <th>Listeners</th>
                    </tr>
                </thead>
                <tbody>
        `;

        // Lặp qua mỗi phần tử trong mảng dữ liệu
        topTracks.forEach((item, index) => {
            tableHtml += `
                <tr>
                    <td>${item.rank}</td>
                    <td>${item.name}</td>
                    <td>${item.artist}</td>
                    <td>${item.listeners}</td>
                </tr>
            `;
        });

        tableHtml += `
                </tbody>
            </table>
        `;

        // Đưa bảng HTML vào một div có id là "table-container"
        $('#table-container').html(tableHtml);

    }).fail(function (jqXHR, textStatus, errorThrown) {
        console.error("Request failed: " + textStatus + ", " + errorThrown);
        $('#table-container').html("An error occurred while loading data.");
    });
});
