const danhSachBanh = [
    {
        id: 1,
        ten: "Bánh Kem Dâu Tây",
        gia: 250000,
        hinh: "images/banh-kem-dau-tay.jpg",
        moTa: "Bánh kem tươi mềm xốp phủ dâu tây Đà Lạt tươi ngon."
    },
    {
        id: 2,
        ten: "Bánh Mì Sừng Bò (Croissant)",
        gia: 35000,
        hinh: "images/croissant.jpg",
        moTa: "Bánh ngàn lớp thơm lừng mùi bơ Pháp béo ngậy."
    },
    {
        id: 3,
        ten: "Bánh Macaron Cầu Vồng",
        gia: 120000,
        hinh: "images/macaron.jpg",
        moTa: "Hộp 6 bánh macaron giòn ngọt đủ màu sắc và hương vị."
    },
    {
        id: 4,
        ten: "Bánh Mousse Xoài",
        gia: 55000,
        hinh: "images/mousse-xoai.jpg",
        moTa: "Bánh mousse mát lạnh vị chua ngọt từ xoài cát tươi."
    },
    {
        id: 5,
        ten: "Bánh Kem Chocolate",
        gia: 280000,
        hinh: "images/banh-chocolate.jpg",
        moTa: "Vị chocolate đen đậm đà ngọt ngào cho bữa tiệc sinh nhật."
    },
    {
        id: 6,
        ten: "Bánh Tiramisu Ý",
        gia: 65000,
        hinh: "images/tiramisu.jpg",
        moTa: "Hương vị cà phê nồng nàn hòa quyện phô mai béo mịn."
    }
];

function dinhDangTien(soTien) {
    return soTien.toLocaleString('vi-VN') + ' đ';
}

function layGioHang() {
    const gioHang = localStorage.getItem("gioHangCuaToi");
    return gioHang ? JSON.parse(gioHang) : [];
}

function luuGioHang(gioHang) {
    localStorage.setItem("gioHangCuaToi", JSON.stringify(gioHang));
    capNhatSoLuongHeader();
}

function capNhatSoLuongHeader() {
    const theSoLuong = document.getElementById("so-luong-gio-hang");
    if (!theSoLuong) return;

    const gioHang = layGioHang();
    const tongSoLuong = gioHang.reduce((sum, item) => sum + item.soLuong, 0);
    theSoLuong.innerText = tongSoLuong;
}

function themVaoGio(idBanh) {
    const banhDuocChon = danhSachBanh.find(b => b.id === idBanh);
    if (!banhDuocChon) return;

    const gioHang = layGioHang();
    const item = gioHang.find(b => b.id === idBanh);

    if (item) {
        item.soLuong += 1;
    } else {
        gioHang.push({
            id: banhDuocChon.id,
            ten: banhDuocChon.ten,
            gia: banhDuocChon.gia,
            hinh: banhDuocChon.hinh,
            soLuong: 1
        });
    }

    luuGioHang(gioHang);
    alert(`Đã thêm [${banhDuocChon.ten}] vào giỏ hàng thành công!`);
}

function hienThiDanhSachBanh(danhSach, idTheChua) {
    const theChua = document.getElementById(idTheChua);
    if (!theChua) return;

    theChua.innerHTML = danhSach.map(b => `
        <div class="the-banh">
            <img src="${b.hinh}" alt="${b.ten}">
            <div class="thong-tin-banh">
                <h3>${b.ten}</h3>
                <p class="mo-ta">${b.moTa}</p>
                <p class="gia-tien">${dinhDangTien(b.gia)}</p>
                <button class="nut-bam" onclick="themVaoGio(${b.id})">Thêm vào giỏ</button>
            </div>
        </div>
    `).join('');
}

function timKiemBanh() {
    const oNhap = document.getElementById("o-tim-kiem");
    if (!oNhap) return;

    const tuKhoa = oNhap.value.toLowerCase().trim();
    const ketQua = danhSachBanh.filter(b => b.ten.toLowerCase().includes(tuKhoa));
    hienThiDanhSachBanh(ketQua, "danh-sach-san-pham");
}

function hienThiTrangGioHang() {
    const theBang = document.getElementById("bang-gio-hang-body");
    const theTongTien = document.getElementById("tong-tien-gio-hang");
    const khungGioHang = document.getElementById("khung-gio-hang");
    const khungTrong = document.getElementById("gio-hang-trong");

    if (!theBang) return;

    const gioHang = layGioHang();

    if (gioHang.length === 0) {
        if (khungGioHang) khungGioHang.style.display = "none";
        if (khungTrong) khungTrong.style.display = "block";
        return;
    }

    if (khungGioHang) khungGioHang.style.display = "block";
    if (khungTrong) khungTrong.style.display = "none";

    let tongTien = 0;
    theBang.innerHTML = gioHang.map(item => {
        const banhGoc = danhSachBanh.find(b => b.id === item.id);
        const hinh = banhGoc ? banhGoc.hinh : item.hinh;
        const thanhTien = item.gia * item.soLuong;
        tongTien += thanhTien;

        return `
            <tr>
                <td>
                    <img src="${hinh}" alt="${item.ten}" class="anh-nho">
                    <span>${item.ten}</span>
                </td>
                <td>${dinhDangTien(item.gia)}</td>
                <td>
                    <button class="nut-tang-giam" onclick="thayDoiSoLuong(${item.id}, -1)">-</button>
                    <span class="so-luong-hien-tai">${item.soLuong}</span>
                    <button class="nut-tang-giam" onclick="thayDoiSoLuong(${item.id}, 1)">+</button>
                </td>
                <td><strong>${dinhDangTien(thanhTien)}</strong></td>
                <td>
                    <button class="nut-xoa" onclick="xoaKhoiGio(${item.id})">Xóa</button>
                </td>
            </tr>
        `;
    }).join('');

    theTongTien.innerText = dinhDangTien(tongTien);
}

function thayDoiSoLuong(idBanh, thayDoi) {
    const gioHang = layGioHang();
    const index = gioHang.findIndex(item => item.id === idBanh);

    if (index !== -1) {
        gioHang[index].soLuong += thayDoi;
        if (gioHang[index].soLuong <= 0) {
            gioHang.splice(index, 1);
        }
        luuGioHang(gioHang);
        hienThiTrangGioHang();
    }
}

function xoaKhoiGio(idBanh) {
    if (confirm("Bạn có chắc muốn xóa món bánh này không?")) {
        const gioHang = layGioHang().filter(item => item.id !== idBanh);
        luuGioHang(gioHang);
        hienThiTrangGioHang();
    }
}

function datHang(event) {
    event.preventDefault();

    const gioHang = layGioHang();
    if (gioHang.length === 0) {
        alert("Giỏ hàng của bạn đang trống!");
        return;
    }

    const hoTen = document.getElementById("dat-hang-hoten").value.trim();
    const sdt = document.getElementById("dat-hang-sdt").value.trim();
    const diaChi = document.getElementById("dat-hang-diachi").value.trim();

    if (!hoTen || !sdt || !diaChi) {
        alert("Vui lòng điền đầy đủ Họ tên, Số điện thoại và Địa chỉ nhận hàng!");
        return;
    }

    alert(`🎉 ĐẶT HÀNG THÀNH CÔNG!\nCảm ơn bạn: ${hoTen}\nSweet Bakery sẽ giao bánh tới địa chỉ: ${diaChi}`);
    luuGioHang([]);
    hienThiTrangGioHang();
}

function guiLienHe(event) {
    event.preventDefault();

    const ten = document.getElementById("lh-ten").value.trim();
    const email = document.getElementById("lh-email").value.trim();
    const tinNhan = document.getElementById("lh-tinnhan").value.trim();

    if (!ten || !email || !tinNhan) {
        alert("Vui lòng điền đầy đủ thông tin trước khi gửi!");
        return;
    }

    alert(`Cảm ơn ${ten}! Lời nhắn của bạn đã được gửi tới tiệm bánh.`);
    document.getElementById("form-lien-he").reset();
}

window.onload = function() {
    capNhatSoLuongHeader();

    if (document.getElementById("danh-sach-trang-chu")) {
        hienThiDanhSachBanh(danhSachBanh.slice(0, 3), "danh-sach-trang-chu");
    }

    if (document.getElementById("danh-sach-san-pham")) {
        hienThiDanhSachBanh(danhSachBanh, "danh-sach-san-pham");
    }

    if (document.getElementById("bang-gio-hang-body")) {
        hienThiTrangGioHang();
    }
};
