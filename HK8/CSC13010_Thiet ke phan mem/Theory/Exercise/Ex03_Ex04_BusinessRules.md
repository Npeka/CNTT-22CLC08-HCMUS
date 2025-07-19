**Bài Kiểm Tra Kỹ Thuật Lập Trình**  

### **Yêu cầu**  
Viết một chương trình quản lý danh sách sinh viên với các chức năng sau:  

1. **Thêm sinh viên mới** – Nhập và lưu thông tin sinh viên vào danh sách. Hỗ trợ thêm mới các giá trị cho **Khoa, Tình trạng sinh viên, Chương trình đào tạo**.  
2. **Xóa sinh viên** – Xóa sinh viên dựa trên Mã số sinh viên (MSSV).  
3. **Cập nhật thông tin sinh viên** – Chỉnh sửa thông tin sinh viên theo MSSV.  
4. **Tìm kiếm sinh viên** – Tìm theo họ tên, MSSV, khoa hoặc kết hợp khoa + tên sinh viên.  
5. **Import/Export dữ liệu** – Hỗ trợ ít nhất **2 định dạng** trong số: **CSV, JSON, XML, Excel**.  
6. **Logging** – Ghi lại logs phục vụ **troubleshooting & audit**.  

### **Thông tin quản lý**  
Chương trình cần lưu trữ các thông tin sau về sinh viên:  

- Mã số sinh viên (MSSV)  
- Họ và tên  
- Ngày tháng năm sinh  
- Giới tính  
- Khoa  
- Khóa  
- Chương trình đào tạo  
- Địa chỉ  
- Email  
- Số điện thoại liên hệ  
- Tình trạng sinh viên  

### **Yêu cầu kỹ thuật**  

- Chương trình có thể được viết bằng bất kỳ ngôn ngữ lập trình nào.  
- Hỗ trợ dạng ứng dụng **console, desktop hoặc web**.  
- Kiểm tra tính hợp lệ của:  
  - **Email** (định dạng hợp lệ)  
  - **Số điện thoại** (đúng quy tắc)  
  - **Tên khoa, tình trạng sinh viên, chương trình đào tạo** (giới hạn danh mục hợp lệ)  
- **Hình thức lưu trữ dữ liệu**:  
  - Chọn ít nhất **một** trong số các định dạng: **XML, JSON, CSV, Database**.  

### **Bổ sung Business Rules** 

## Ex03
01. MSSV phải là duy nhất  
   - Khi thêm hoặc cập nhật sinh viên, không được trùng MSSV với sinh viên khác.  

02. Email phải thuộc một tên miền nhất định và có thể cấu hình động (configurable) 
   - Ví dụ: Chỉ chấp nhận email có đuôi `@student.university.edu.vn`.  

03. Số điện thoại phải có định dạng hợp lệ theo quốc gia (configurable) 
   - Ví dụ: Việt Nam (`+84` hoặc `0[3|5|7|8|9]xxxxxxxx`).  		 

04. Tình trạng sinh viên chỉ có thể thay đổi theo một số quy tắc (configurable)
   - Ví dụ:  
     - `"Đang học"` → `"Bảo lưu"`, `"Tốt nghiệp"`, `"Đình chỉ"` (hợp lệ).  
     - `"Đã tốt nghiệp"` không thể quay lại `"Đang học"`.  

## Ex04
	 
05. Có thể gửi email / SMS / Zalo đến sinh viên về biến động trạng thái tùy vào SV đã đăng ký những hình thức notification nào (*không bắt buộc*)
	
06. Chỉ được phép xóa sinh viên có creation date/time trong khoảng thời gian nhất định. Ví dụ: 30 phút (configurable) 

07. Cho phép bật / tắt việc áp dụng các quy định 

08. Các màn hình cần hiện logo hoặc tên Trường (ít nhất một)

09. Cho phép xóa khoa, xóa tình trạng sinh viên, xóa chương trình đào tạo nếu không có ràng buộc về dữ liệu 

10. Xuất giấy xác nhận tình trạng sinh viên ra **HTML/MD/PDF/DOCX** (ít nhất 2 định dạng)
---

**TRƯỜNG ĐẠI HỌC [Tên Trường]**  
**PHÒNG ĐÀO TẠO**  
📍 Địa chỉ: [Địa chỉ trường]  
📞 Điện thoại: [Số điện thoại] | 📧 Email: [Email liên hệ]  

---

### **GIẤY XÁC NHẬN TÌNH TRẠNG SINH VIÊN**  

Trường Đại học [Tên Trường] xác nhận:  

**1. Thông tin sinh viên:**  
- **Họ và tên:** [Họ và tên sinh viên]  
- **Mã số sinh viên:** [MSSV]  
- **Ngày sinh:** [DD/MM/YYYY]  
- **Giới tính:** [Nam/Nữ/Khác]  
- **Khoa:** [Tên khoa]  
- **Chương trình đào tạo:** [Cử nhân/Kỹ sư/Thạc sĩ...]  
- **Khóa:** [KXX - Năm nhập học]  

**2. Tình trạng sinh viên hiện tại:** 
- Đang theo học
- Đã hoàn thành chương trình, chờ xét tốt nghiệp
- Đã tốt nghiệp
- Bảo lưu 
- Đình chỉ học tập
- Tình trạng khác 
 
**3. Mục đích xác nhận:**  
- Xác nhận đang học để vay vốn ngân hàng  
- Xác nhận làm thủ tục tạm hoãn nghĩa vụ quân sự  
- Xác nhận làm hồ sơ xin việc / thực tập 
- Xác nhận lý do khác: [Ghi rõ]  

**4. Thời gian cấp giấy:**  
- Giấy xác nhận có hiệu lực đến ngày: [DD/MM/YYYY]  (tùy vào mục đích xác nhận)

📍 **Xác nhận của Trường Đại học [Tên Trường]**  

📅 Ngày cấp: [DD/MM/YYYY]  

🖋 **Trưởng Phòng Đào Tạo**  
(Ký, ghi rõ họ tên, đóng dấu)  

---

### **Các tính năng cần hỗ trợ trong ứng dụng:**  
✔️ Xuất giấy xác nhận ra **HTML/MD/PDF/DOCX**  (ít nhất 2 định dạng)

----------------------------------------------------------------------------------------------------

### **Lưu ý**  
Chương trình cần đảm bảo **tính đúng đắn, dễ kiểm thử**.



