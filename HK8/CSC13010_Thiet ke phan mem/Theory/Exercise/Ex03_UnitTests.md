# **Yêu Cầu Unit Test cho Ứng Dụng Quản Lý Sinh Viên**  

## **1. Tìm Hiểu về Unit Test Coverage và Best Practices**  
Sinh viên cần nghiên cứu và tổng hợp về các tiêu chuẩn unit test coverage trong industry, bao gồm:  

### **🔹 Các Loại Code Coverage Quan Trọng:**  
- **Line Coverage** – Kiểm tra tỷ lệ dòng code được thực thi.  
- **Branch Coverage** – Đảm bảo tất cả các nhánh (`if`, `else`, `switch`) được kiểm thử.  
- **Function Coverage** – Xác minh tất cả các hàm/method được gọi ít nhất một lần.  
- **Path Coverage** – Đảm bảo các đường đi logic quan trọng đều được test.  

### **🔹 Mức Coverage Tối Thiểu:**  
- Tìm hiểu mức độ code coverage phù hợp với các hệ thống tương tự trong industry.  
- Coverage không cần phải quá cao nhưng phải đảm bảo kiểm thử đủ các logic quan trọng.  

### **🔹 Best Practices Khi Viết Unit Test:**  
- Viết unit test dễ bảo trì, không phụ thuộc vào **database** hoặc **persistent storage** (dùng mock dependency khi cần).  
- Đảm bảo kiểm thử cả **happy case** (thành công) lẫn **edge case** (dữ liệu không hợp lệ).  
- Không viết test trùng lặp hoặc quá phụ thuộc vào implementation details.  

📌 **Yêu Cầu Báo Cáo:**  
- Báo cáo lại ngắn gọn kết quả tìm hiểu về coverage và best practices.  
- Có thể sử dụng công cụ AI để hỗ trợ nghiên cứu.  

---

## **2. Viết Unit Test Cho Ứng Dụng**  

- Không cần viết quá nhiều test, chỉ tập trung vào các **logic và thành phần quan trọng**.  

---

## **3. Đánh Giá và Cải Tiến Thiết Kế Nếu Cần**  
Nếu gặp nhiều khó khăn khi viết unit test/integration test, có thể cần **thiết kế lại chương trình**. Xem xét các vấn đề sau:  

### **🔹 Các Vấn Đề Cần Đánh Giá:**  
- **Phụ thuộc quá nhiều vào database/persistent storage** → Dùng **mock/stub** để test dễ dàng hơn.  
- **Module có quá nhiều trách nhiệm** → Cần **tách nhỏ** thành các service hợp lý hơn.  
- **Không test được business logic quan trọng** → Có thể thiếu **layer xử lý logic** đúng chỗ.  

### **🔹 Yêu Cầu Báo Cáo Cải Tiến:**  
- Nếu gặp vấn đề khi test, cần viết báo cáo ngắn gọn về **khó khăn** và **cách cải thiện thiết kế**.  
- Đề xuất các **thay đổi code** nếu cần để làm cho ứng dụng dễ test hơn.  

📌 **Lưu Ý:**  
- Phần tìm hiểu về **unit test** có thể làm theo **nhóm**.  
- Phần thực hiện **unit test** và đánh giá cải tiến phải làm **cá nhân**.  
---
