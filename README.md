# API Top Bài Hát với FastAPI

Dự án này cung cấp một API đơn giản sử dụng FastAPI để quản lý và truy xuất các bài hát được nghe nhiều nhất. API cho phép bạn thêm bài hát mới, cập nhật số lượt nghe cho mỗi bài hát, và truy xuất danh sách các bài hát hàng đầu.

## Tính Năng

- **Thêm bài hát mới**: Thêm một bài hát mới vào cơ sở dữ liệu với số lượt nghe ban đầu.
- **Cập nhật lượt nghe của bài hát**: Cập nhật số lượt nghe cho một bài hát nhất định.
- **Lấy danh sách bài hát hàng đầu**: Truy xuất danh sách các bài hát được sắp xếp theo số lượt nghe.
- 
## Lược Đồ Cơ Sở Dữ Liệu
Lược đồ cơ sở dữ liệu bao gồm một bảng tracks với các cột sau:
- id (int, khóa chính)
- name (string)
- artist (string)
- listens (int)
