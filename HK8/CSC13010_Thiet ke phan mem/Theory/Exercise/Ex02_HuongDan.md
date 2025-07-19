# **Hướng Dẫn Nộp Bài Tập Ex01 (nộp lại) & Ex02 (nộp mới)**

## **1. Nộp Bài Ex01**

### **Bước 1: Tạo GitHub Repository**

- Đăng nhập vào [GitHub](https://github.com/) và tạo một repository mới.
- Đặt tên repository phù hợp với nội dung bài tập.

### **Bước 2: Push Source Code & Tạo Tag v1.0**

- Clone repository về máy:
  ```bash
  git clone https://github.com/your-username/your-repo.git
  cd your-repo
  ```
- Thêm toàn bộ source code đã thực hiện ở Ex01 (chính xác như những gì đã nộp trên Moodle).
- Commit và push lên GitHub:
  ```bash
  git add .
  git commit -m "Initial commit - Version 1.0"
  git push origin main
  ```
- Tạo Git tag cho phiên bản 1.0:
  ```bash
  git tag v1.0
  git push origin v1.0
  ```

### **Bước 3: Bổ Sung Hình Ảnh Minh Chứng**

- Chụp ảnh (screenshots) minh chứng các chức năng chính của **Version 1.0**.
- Lưu ảnh vào thư mục `screenshots/` trong repository.
- Cập nhật file `README.md` để mô tả chức năng kèm hình ảnh.

### **Bước 4: Nộp Bài Lên Moodle**

- Tạo file `MSSV.txt` chứa link GitHub repository của bạn.
- Upload file `MSSV.txt` lên Moodle **càng sớm càng tốt**.

---

## **2. Tiếp Tục Phát Triển Version 2.0**

### **Danh Sách Các Tính Năng Cần Thêm Mới**

✅ **Lưu trữ dữ liệu:**

- Sử dụng **XML, JSON, CSV, Database**, hoặc hình thức lưu trữ khác (**chọn ít nhất một**).

✅ **Cho phép đổi tên & thêm mới:**

- **Khoa (Faculty)**
- **Tình trạng sinh viên (Student Status)**
- **Chương trình đào tạo (Program)**

✅ **Thêm chức năng tìm kiếm:**

- **Tìm theo khoa**
- **Tìm theo khoa + tên sinh viên**

✅ **Hỗ trợ import/export dữ liệu:**

- **CSV, JSON, XML, Excel** (**chọn ít nhất 2**)

✅ **Thêm logging mechanism:**

- Ghi lại logs để **troubleshooting production issues & audit purposes**.

✅ **Thêm chức năng show version và ngày build ứng dụng**
---

## **3. Cách Commit Code**

- **Mỗi commit phải gắn với một task/subtask cụ thể**.
- **Ví dụ:**
  ```bash
  git commit -m "Added faculty renaming feature"
  git commit -m "Implemented student search by faculty and name"
  git commit -m "Added CSV import/export functionality"
  git commit -m "Integrated logging for debugging and auditing"
  git commit -m "Fix search screen background color mismatch"
  ```

---

## **4. Cập Nhật README.md & Tạo Tag v2.0**

### **Bước 1: Cập Nhật README.md**

- Bổ sung hướng dẫn sử dụng **Version 2.0**.
- Thêm hình ảnh minh chứng các tính năng mới.
- Ghi rõ nếu có yêu cầu nào chưa hoàn thành hoặc chưa làm kịp.

### **Bước 2: Tạo Git Tag v2.0**

- Sau khi hoàn thành tất cả các tính năng:
  ```bash
  git tag v2.0
  git push origin v2.0
  ```

✅ **Đảm bảo tag được tạo và push lên GitHub trước thời hạn nộp bài.**

---
