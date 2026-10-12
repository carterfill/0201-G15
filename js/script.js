

const danhSachDanhMuc = [
    { ma: "tat-ca", ten: "Tất Cả Sản Phẩm", moTa: "Thế giới bánh ngọt ngào nướng mới mỗi sáng" },
    { ma: "banh-kem", ten: "Bánh Kem Sinh Nhật", moTa: "Bánh kem tươi cao cấp cho ngày kỷ niệm ý nghĩa" },
    { ma: "banh-mi", ten: "Bánh Mì & Pastry", moTa: "Bánh mì sừng bò, bánh nướng chuẩn phong cách Pháp" },
    { ma: "mousse-lanh", ten: "Bánh Mousse & Bánh Lạnh", moTa: "Mát lạnh mềm mịn xua tan cái nóng ngày hè" },
    { ma: "macaron-cookie", ten: "Macaron & Cookie", moTa: "Bánh tráng miệng nhỏ xinh hương vị tinh tế" }
];

const danhSachBanh = [
    {
        id: 1,
        ten: "Bánh Kem Dâu Tây Đà Lạt",
        gia: 250000,
        giaGoc: 290000,
        danhMuc: "banh-kem",
        tenDanhMuc: "Bánh Kem Sinh Nhật",
        hinh: "images/banh-kem-dau-tay.jpg",
        moTa: "Bánh kem tươi mềm xốp phủ ngập dâu tây Đà Lạt tươi mọng ngọt dịu.",
        moTaChiTiet: "Bánh kem dâu tây là món bán chạy nhất tại Sweet Bakery. Cốt bánh chiffon vani mềm xốp kết hợp hoàn hảo cùng kem tươi whipping béo nhẹ từ New Zealand, ít ngọt không ngấy. Bề mặt bánh được trang trí bằng những trái dâu tây Đà Lạt tuyển chọn kỹ lưỡng, mọng nước và thơm nồng.",
        thanhPhan: "Cốt bông lan Chiffon vani, kem sữa tươi New Zealand, dâu tây tươi Đà Lạt, mứt dâu handmade, lá hương thảo trang trí.",
        baoQuan: "Bảo quản ở nhiệt độ 2 - 6°C trong tủ mát. Dùng ngon nhất trong vòng 24 - 48 giờ sau khi nhận bánh.",
        kichThuoc: "Size 16cm (4 - 6 người) | Tặng kèm nến, muỗng, dao cắt bánh",
        sao: 5,
        daBan: 218,
        hot: true
    },
    {
        id: 2,
        ten: "Bánh Mì Sừng Bò (Croissant Bơ Pháp)",
        gia: 35000,
        giaGoc: 45000,
        danhMuc: "banh-mi",
        tenDanhMuc: "Bánh Mì & Pastry",
        hinh: "images/croissant.jpg",
        moTa: "Bánh ngàn lớp giòn rụm bên ngoài, thơm lừng bơ Pháp cao cấp bên trong.",
        moTaChiTiet: "Croissant truyền thống chuẩn kỹ thuật cán bột thủ công nhiều lớp. Khi nướng chín, bánh nở bung phồng xốp giòn rụm, từng thớ bánh thơm lừng mùi bơ Elle & Vire nhập khẩu từ Pháp. Thích hợp dùng kèm cà phê hoặc trà nóng cho bữa sáng tràn đầy năng lượng.",
        thanhPhan: "Bột mì thượng hạng, bơ lạt nguyên chất Elle & Vire Pháp, men tươi nở chậm, sữa tươi không đường, muối biển.",
        baoQuan: "Bảo quản nơi khô ráo, thoáng mát trong 2 ngày. Có thể hâm nóng lại bằng nồi chiên không dầu 160°C trong 3 phút để vỏ giòn lại.",
        kichThuoc: "Trọng lượng 85g / chiếc | Nướng mới 2 mẻ mỗi ngày: 7h00 và 14h00",
        sao: 5,
        daBan: 540,
        hot: true
    },
    {
        id: 3,
        ten: "Bánh Macaron Cầu Vồng Pháp",
        gia: 120000,
        giaGoc: 150000,
        danhMuc: "macaron-cookie",
        tenDanhMuc: "Macaron & Cookie",
        hinh: "images/macaron.jpg",
        moTa: "Hộp 6 bánh macaron giòn ngọt đủ màu sắc và các vị trái cây tự nhiên.",
        moTaChiTiet: "Hộp quà tặng Macaron 6 chiếc gồm 6 hương vị tinh tế: Dâu tây, Matcha Nhật Bản, Chocolate đen, Chanh dây, Việt quất và Vani Madagascar. Vỏ bánh giòn xốp bên ngoài, dẻo dai bên trong cùng lớp nhân ganache sánh mịn tan ngay trên đầu lưỡi.",
        thanhPhan: "Bột hạnh nhân xay mịn, đường bột cao cấp, lòng trắng trứng tiệt trùng, bơ hạt dẻ, sô cô la Callebaut, chiết xuất trái cây tự nhiên.",
        baoQuan: "Bảo quản ngăn mát tủ lạnh dùng trong 5 ngày. Đem ra nhiệt độ phòng khoảng 10 phút trước khi thưởng thức.",
        kichThuoc: "Hộp 6 chiếc có nơ thắt sang trọng thích hợp làm quà tặng",
        sao: 5,
        daBan: 185,
        hot: false
    },
    {
        id: 4,
        ten: "Bánh Mousse Xoài Nhiệt Đới",
        gia: 55000,
        giaGoc: 65000,
        danhMuc: "mousse-lanh",
        tenDanhMuc: "Bánh Mousse & Bánh Lạnh",
        hinh: "images/mousse-xoai.jpg",
        moTa: "Bánh mousse mát lạnh vị chua ngọt thanh mát từ xoài cát Hòa Lộc.",
        moTaChiTiet: "Chiếc bánh mousse thanh mát là lựa chọn tuyệt vời cho những ai yêu thích vị chua ngọt tự nhiên của trái cây nhiệt đới. Lớp mousse vàng ươm núng nính làm từ sốt xoài cát tươi nguyên chất, bên dưới là đế bánh bông lan mềm mịn và lớp thạch gương xoài bóng bẩy bên trên.",
        thanhPhan: "Thịt xoài cát tươi, gelatin lá Đức, kem whipping tươi, sữa chua không đường, đế bông lan vani, đường mía.",
        baoQuan: "Bảo quản liên tục trong ngăn mát tủ lạnh từ 1 - 4°C. Dùng ngon nhất trong vòng 2 ngày.",
        kichThuoc: "Cúp bánh tam giác trọng lượng 120g",
        sao: 4,
        daBan: 312,
        hot: true
    },
    {
        id: 5,
        ten: "Bánh Kem Chocolate Truffle",
        gia: 280000,
        giaGoc: 320000,
        danhMuc: "banh-kem",
        tenDanhMuc: "Bánh Kem Sinh Nhật",
        hinh: "images/banh-chocolate.jpg",
        moTa: "Vị chocolate đen 70% Bỉ đậm đà, sang trọng cho các bữa tiệc sinh nhật.",
        moTaChiTiet: "Bánh Kem Chocolate Truffle là tuyệt tác dành riêng cho các tín đồ mê sô-cô-la đích thực. Lớp ganache bóng loáng phủ bên ngoài lớp kem mousse chocolate đen 70% từ vương quốc Bỉ, xen kẽ với các tầng cốt bánh ẩm mượt đậm đà, đắng nhẹ hậu vị ngọt ngào.",
        thanhPhan: "Chocolate đen nguyên chất 70% Bỉ, bột ca cao nguyên chất, kem whipping béo, cốt bánh bông lan chocolate ẩm, rượu rum nhẹ.",
        baoQuan: "Bảo quản ở nhiệt độ mát 2 - 6°C. Tránh để nơi có ánh nắng trực tiếp hoặc nhiệt độ cao.",
        kichThuoc: "Size 18cm (6 - 8 người) | Tặng kèm trọn bộ nến hoa sen và phụ kiện tiệc",
        sao: 5,
        daBan: 198,
        hot: true
    },
    {
        id: 6,
        ten: "Bánh Tiramisu Ý Cổ Điển",
        gia: 65000,
        giaGoc: 75000,
        danhMuc: "mousse-lanh",
        tenDanhMuc: "Bánh Mousse & Bánh Lạnh",
        hinh: "images/tiramisu.jpg",
        moTa: "Hương vị cà phê nồng nàn hòa quyện phô mai Mascarpone béo ngậy thơm ngon.",
        moTaChiTiet: "Tiramisu chuẩn vị nước Ý được làm từ phô mai Mascarpone nhập khẩu kết hợp cùng từng chiếc bánh sâm-panh (Ladyfinger) thấm đẫm cà phê espresso đậm đà và chút rượu Marsala thơm nồng. Phía trên rắc một lớp bột cacao đắng tạo nên sự cân bằng hương vị hoàn hảo.",
        thanhPhan: "Phô mai Mascarpone Ý, bánh Ladyfinger, cà phê Espresso thượng hạng, rượu hương nồng nhẹ, trứng gà tiệt trùng, bột cacao nguyên chất.",
        baoQuan: "Bảo quản trong ngăn mát 2 - 5°C. Thưởng thức lạnh để cảm nhận rõ từng tầng hương vị béo ngậy.",
        kichThuoc: "Hộp thiếc vintage hoặc hộp mica 150g",
        sao: 5,
        daBan: 420,
        hot: true
    },
    {
        id: 7,
        ten: "Bánh Mì Sừng Bò Hạnh Nhân",
        gia: 45000,
        giaGoc: 55000,
        danhMuc: "banh-mi",
        tenDanhMuc: "Bánh Mì & Pastry",
        hinh: "images/croissant.jpg",
        moTa: "Croissant phủ sốt kem hạnh nhân béo ngậy và hạt hạnh nhân thái lát giòn rụm.",
        moTaChiTiet: "Phiên bản nâng cấp đặc biệt của Croissant bơ truyền thống: bánh được quét đẫm một lớp kem hạnh nhân ngọt bùi (Frangipane) từ trong ra ngoài, sau đó rắc ngập tràn hạnh nhân lát nướng thơm vàng giòn rụm.",
        thanhPhan: "Bột mì Pháp, bơ lạt nguyên chất, bột hạnh nhân, hạnh nhân lát sấy giòn, đường bột trang trí.",
        baoQuan: "Bảo quản ở nhiệt độ phòng trong 24 giờ hoặc ngăn mát tủ lạnh 3 ngày.",
        kichThuoc: "Trọng lượng 110g / chiếc",
        sao: 5,
        daBan: 176,
        hot: false
    },
    {
        id: 8,
        ten: "Bánh Kem Dâu Phô Mai Tươi",
        gia: 260000,
        giaGoc: 300000,
        danhMuc: "banh-kem",
        tenDanhMuc: "Bánh Kem Sinh Nhật",
        hinh: "images/banh-kem-dau-tay.jpg",
        moTa: "Sự kết hợp quyến rũ giữa kem phô mai béo ngậy và mứt dâu tây chua thanh.",
        moTaChiTiet: "Dành cho những bạn thích vị phô mai đậm đà nhưng không hề bị ngấy. Cốt bánh vani xen lẫn lớp phô mai kem mịn màng và dâu tươi cắt hạt lựu, mang đến cảm giác tan chảy ngay khi thưởng thức miếng đầu tiên.",
        thanhPhan: "Cream cheese cao cấp, kem tươi động vật, dâu tây tươi, sốt dâu nấu thủ công, cốt bông lan mềm mịn.",
        baoQuan: "Bảo quản tủ lạnh từ 2 - 5°C. Hạn sử dụng trong 48 giờ.",
        kichThuoc: "Size 16cm (4 - 6 người ăn)",
        sao: 5,
        daBan: 145,
        hot: false
    }
];

function dinhDangTien(soTien) {
    if (typeof soTien !== 'number') soTien = Number(soTien) || 0;
    return soTien.toLocaleString('vi-VN') + ' đ';
}

function layThamSoUrl(tenThamSo) {
    const searchParams = new URLSearchParams(window.location.search);
    return searchParams.get(tenThamSo);
}

function layGioHang() {
    try {
        const gioHang = localStorage.getItem("gioHangCuaToi");
        return gioHang ? JSON.parse(gioHang) : [];
    } catch (e) {
        return [];
    }
}

function luuGioHang(gioHang) {
    localStorage.setItem("gioHangCuaToi", JSON.stringify(gioHang));
    capNhatSoLuongHeader();
}

function capNhatSoLuongHeader() {
    const theSoLuong = document.getElementById("so-luong-gio-hang");
    if (!theSoLuong) return;
    const gioHang = layGioHang();
    const tongSoLuong = gioHang.reduce((sum, item) => sum + (item.soLuong || 1), 0);
    theSoLuong.innerText = tongSoLuong;
}

function themVaoGio(idBanh, soLuong = 1, hienThongBao = true) {
    const banhDuocChon = danhSachBanh.find(b => b.id === Number(idBanh));
    if (!banhDuocChon) return;

    soLuong = parseInt(soLuong) || 1;
    if (soLuong <= 0) soLuong = 1;

    const gioHang = layGioHang();
    const item = gioHang.find(b => b.id === banhDuocChon.id);

    if (item) {
        item.soLuong += soLuong;
    } else {
        gioHang.push({
            id: banhDuocChon.id,
            ten: banhDuocChon.ten,
            gia: banhDuocChon.gia,
            giaGoc: banhDuocChon.giaGoc,
            hinh: banhDuocChon.hinh,
            danhMuc: banhDuocChon.danhMuc,
            soLuong: soLuong
        });
    }

    luuGioHang(gioHang);

    if (hienThongBao) {
        hienThiToast(`Đã thêm ${soLuong} x [${banhDuocChon.ten}] vào giỏ hàng thành công! 🛒`);
    }
}

function muaNgay(idBanh, soLuong = 1) {
    themVaoGio(idBanh, soLuong, false);
    window.location.href = "checkout.html";
}

function hienThiToast(noiDung, loai = "thanh-cong") {
    let toastContainer = document.getElementById("toast-container");
    if (!toastContainer) {
        toastContainer = document.createElement("div");
        toastContainer.id = "toast-container";
        toastContainer.className = "toast-container";
        document.body.appendChild(toastContainer);
    }

    const toast = document.createElement("div");
    toast.className = `toast-item toast-${loai}`;
    toast.innerHTML = `
        <span class="toast-icon">${loai === 'thanh-cong' ? '✅' : 'ℹ️'}</span>
        <span class="toast-msg">${noiDung}</span>
    `;
    toastContainer.appendChild(toast);

    setTimeout(() => {
        toast.classList.add("toast-show");
    }, 10);

    setTimeout(() => {
        toast.classList.remove("toast-show");
        setTimeout(() => toast.remove(), 300);
    }, 3500);
}

function layNguoiDungHienTai() {
    try {
        const user = localStorage.getItem("sweetBakeryUser");
        return user ? JSON.parse(user) : null;
    } catch (e) {
        return null;
    }
}

function luuNguoiDungHienTai(user) {
    localStorage.setItem("sweetBakeryUser", JSON.stringify(user));
    capNhatGiaoDienTaiKhoan();
}

function dangXuat() {
    if (confirm("Bạn có chắc chắn muốn đăng xuất không?")) {
        localStorage.removeItem("sweetBakeryUser");
        hienThiToast("Đã đăng xuất tài khoản thành công!");
        setTimeout(() => {
            window.location.href = "index.html";
        }, 800);
    }
}

function capNhatGiaoDienTaiKhoan() {
    const khuVucTaiKhoan = document.getElementById("khu-vuc-tai-khoan");
    if (!khuVucTaiKhoan) return;

    const user = layNguoiDungHienTai();
    if (user) {
        khuVucTaiKhoan.innerHTML = `
            <div class="user-logged-in">
                <span class="user-greeting">👋 Chào, <strong>${user.hoTen}</strong></span>
                <a href="order-history.html" class="user-link">Lịch Sử Mua Hàng</a>
                <button type="button" class="btn-logout" onclick="dangXuat()">Đăng Xuất</button>
            </div>
        `;
    } else {
        khuVucTaiKhoan.innerHTML = `
            <div class="user-auth-links">
                <a href="order-history.html" class="auth-btn btn-lookup">Tra Cứu Đơn</a>
                <a href="login.html" class="auth-btn btn-login">Đăng Nhập</a>
                <a href="register.html" class="auth-btn btn-register">Đăng Ký</a>
            </div>
        `;
    }
}

function khoiTaoDonHangMau() {
    if (!localStorage.getItem("danhSachDonHang")) {
        const donHangMau = [
            {
                maDon: "SB-8821",
                ngayDat: "10/10/2026 14:30",
                hoTen: "Trần Mai Anh",
                sdt: "0918123456",
                email: "maianh@example.com",
                diaChi: "Số 45 Lê Duẩn, Bến Nghé, Quận 1, TP. Hồ Chí Minh",
                ghiChu: "Vui lòng vẽ chữ 'Chúc mừng sinh nhật Mẹ' lên bánh kem giúp mình nhé!",
                phuongThucThanhToan: "Chuyển khoản QR Ngân hàng",
                trangThaiThanhToan: "Đã thanh toán",
                trangThaiDon: "Đã giao hàng",
                maTrangThai: 4,
                phiShip: 25000,
                giamGia: 20000,
                tamTinh: 315000,
                tongTien: 320000,
                sanPham: [
                    { id: 1, ten: "Bánh Kem Dâu Tây Đà Lạt", gia: 250000, hinh: "images/banh-kem-dau-tay.jpg", soLuong: 1 },
                    { id: 6, ten: "Bánh Tiramisu Ý Cổ Điển", gia: 65000, hinh: "images/tiramisu.jpg", soLuong: 1 }
                ]
            },
            {
                maDon: "SB-8902",
                ngayDat: "12/10/2026 09:15",
                hoTen: "Nguyễn Văn Tuấn",
                sdt: "0909876543",
                email: "tuan.nguyen@example.com",
                diaChi: "120 Điện Biên Phủ, Phường 15, Quận Bình Thạnh, TP. Hồ Chí Minh",
                ghiChu: "Giao trước 11h trưa để kịp liên hoan văn phòng",
                phuongThucThanhToan: "Tiền mặt khi nhận bánh (COD)",
                trangThaiThanhToan: "Chưa thanh toán",
                trangThaiDon: "Đang nướng bánh & chuẩn bị",
                maTrangThai: 2,
                phiShip: 15000,
                giamGia: 0,
                tamTinh: 190000,
                tongTien: 205000,
                sanPham: [
                    { id: 2, ten: "Bánh Mì Sừng Bò (Croissant Bơ Pháp)", gia: 35000, hinh: "images/croissant.jpg", soLuong: 2 },
                    { id: 3, ten: "Bánh Macaron Cầu Vồng Pháp", gia: 120000, hinh: "images/macaron.jpg", soLuong: 1 }
                ]
            }
        ];
        localStorage.setItem("danhSachDonHang", JSON.stringify(donHangMau));
    }
}

function layDanhSachDonHang() {
    khoiTaoDonHangMau();
    try {
        const ds = localStorage.getItem("danhSachDonHang");
        return ds ? JSON.parse(ds) : [];
    } catch (e) {
        return [];
    }
}

function luuDanhSachDonHang(ds) {
    localStorage.setItem("danhSachDonHang", JSON.stringify(ds));
}

function taoTheBanhHtml(b) {
    const saleTag = b.giaGoc ? `<span class="nhan-giam-gia">-${Math.round((1 - b.gia/b.giaGoc)*100)}%</span>` : '';
    const giaGocHtml = b.giaGoc ? `<span class="gia-goc">${dinhDangTien(b.giaGoc)}</span>` : '';
    const badgeHot = b.hot ? `<span class="nhan-hot">🔥 Bán chạy</span>` : '';

    return `
        <div class="the-banh" data-id="${b.id}" data-category="${b.danhMuc}">
            <div class="khung-anh-banh">
                <a href="product-detail.html?id=${b.id}">
                    <img src="${b.hinh}" alt="${b.ten}" loading="lazy">
                </a>
                ${saleTag}
                ${badgeHot}
            </div>
            <div class="thong-tin-banh">
                <span class="the-danh-muc-nho">${b.tenDanhMuc}</span>
                <h3><a href="product-detail.html?id=${b.id}">${b.ten}</a></h3>
                <div class="danh-gia-sao">
                    <span class="sao">★★★★★</span>
                    <span class="da-ban">Đã bán ${b.daBan || 100}+</span>
                </div>
                <p class="mo-ta">${b.moTa}</p>
                <div class="khung-gia-ban">
                    <span class="gia-tien">${dinhDangTien(b.gia)}</span>
                    ${giaGocHtml}
                </div>
                <div class="nhom-nut-the">
                    <a href="product-detail.html?id=${b.id}" class="nut-xem-chi-tiet">Chi Tiết</a>
                    <button class="nut-bam nut-them-nhanh" onclick="themVaoGio(${b.id})">
                        <span>🛒 Thêm Giỏ</span>
                    </button>
                </div>
            </div>
        </div>
    `;
}

function hienThiDanhSachBanh(danhSach, idTheChua) {
    const theChua = document.getElementById(idTheChua);
    if (!theChua) return;

    if (!danhSach || danhSach.length === 0) {
        theChua.innerHTML = `
            <div class="khong-tim-thay">
                <p class="icon-empty">🧁</p>
                <h4>Không tìm thấy món bánh phù hợp!</h4>
                <p>Hãy thử tìm bằng từ khóa khác hoặc bỏ các tiêu chí lọc nhé.</p>
            </div>
        `;
        return;
    }

    theChua.innerHTML = danhSach.map(b => taoTheBanhHtml(b)).join('');
}

let boLocHienTai = {
    danhMuc: "tat-ca",
    khoangGia: "tat-ca",
    sapXep: "mac-dinh",
    tuKhoa: ""
};

function khoiTaoTrangSanPham() {
    const urlDm = layThamSoUrl("danhMuc");
    if (urlDm) {
        boLocHienTai.danhMuc = urlDm;
    }

    const radioDm = document.querySelector(`input[name="filter-danhmuc"][value="${boLocHienTai.danhMuc}"]`);
    if (radioDm) radioDm.checked = true;

    renderPillsDanhMuc();
    apDungBoLocSanPham();
}

function renderPillsDanhMuc() {
    const container = document.getElementById("category-pills");
    if (!container) return;

    container.innerHTML = danhSachDanhMuc.map(dm => `
        <button type="button" class="pill-category ${boLocHienTai.danhMuc === dm.ma ? 'active' : ''}" 
                onclick="chonDanhMucQuick('${dm.ma}')">
            ${dm.ten}
        </button>
    `).join('');
}

function chonDanhMucQuick(maDm) {
    boLocHienTai.danhMuc = maDm;
    const radioDm = document.querySelector(`input[name="filter-danhmuc"][value="${maDm}"]`);
    if (radioDm) radioDm.checked = true;
    renderPillsDanhMuc();
    apDungBoLocSanPham();
}

function apDungBoLocSanPham() {
    let ketQua = [...danhSachBanh];

    if (boLocHienTai.danhMuc && boLocHienTai.danhMuc !== "tat-ca") {
        ketQua = ketQua.filter(b => b.danhMuc === boLocHienTai.danhMuc);
    }

    const radioGia = document.querySelector('input[name="filter-gia"]:checked');
    if (radioGia) {
        boLocHienTai.khoangGia = radioGia.value;
        if (boLocHienTai.khoangGia === "duoi-50") {
            ketQua = ketQua.filter(b => b.gia < 50000);
        } else if (boLocHienTai.khoangGia === "50-150") {
            ketQua = ketQua.filter(b => b.gia >= 50000 && b.gia <= 150000);
        } else if (boLocHienTai.khoangGia === "tren-150") {
            ketQua = ketQua.filter(b => b.gia > 150000);
        }
    }

    const oTimKiem = document.getElementById("o-tim-kiem");
    if (oTimKiem) {
        boLocHienTai.tuKhoa = oTimKiem.value.toLowerCase().trim();
        if (boLocHienTai.tuKhoa) {
            ketQua = ketQua.filter(b => b.ten.toLowerCase().includes(boLocHienTai.tuKhoa) || b.moTa.toLowerCase().includes(boLocHienTai.tuKhoa));
        }
    }

    const selectSapXep = document.getElementById("select-sap-xep");
    if (selectSapXep) {
        boLocHienTai.sapXep = selectSapXep.value;
        if (boLocHienTai.sapXep === "gia-tang") {
            ketQua.sort((a, b) => a.gia - b.gia);
        } else if (boLocHienTai.sapXep === "gia-giam") {
            ketQua.sort((a, b) => b.gia - a.gia);
        } else if (boLocHienTai.sapXep === "ten-az") {
            ketQua.sort((a, b) => a.ten.localeCompare(b.ten, 'vi'));
        } else if (boLocHienTai.sapXep === "ban-chay") {
            ketQua.sort((a, b) => (b.daBan || 0) - (a.daBan || 0));
        }
    }

    const theDem = document.getElementById("so-luong-ket-qua");
    if (theDem) {
        theDem.innerText = `Tìm thấy ${ketQua.length} món bánh`;
    }

    hienThiDanhSachBanh(ketQua, "danh-sach-san-pham");
}

function datLaiBoLoc() {
    boLocHienTai = {
        danhMuc: "tat-ca",
        khoangGia: "tat-ca",
        sapXep: "mac-dinh",
        tuKhoa: ""
    };
    const radioDmAll = document.querySelector('input[name="filter-danhmuc"][value="tat-ca"]');
    if (radioDmAll) radioDmAll.checked = true;

    const radioGiaAll = document.querySelector('input[name="filter-gia"][value="tat-ca"]');
    if (radioGiaAll) radioGiaAll.checked = true;

    const selectSx = document.getElementById("select-sap-xep");
    if (selectSx) selectSx.value = "mac-dinh";

    const oTim = document.getElementById("o-tim-kiem");
    if (oTim) oTim.value = "";

    renderPillsDanhMuc();
    apDungBoLocSanPham();
}

function hienThiTrangChiTietSanPham() {
    const idParam = layThamSoUrl("id");
    const idBanh = idParam ? parseInt(idParam) : 1;
    const banh = danhSachBanh.find(b => b.id === idBanh) || danhSachBanh[0];

    document.title = `${banh.ten} - Sweet Bakery`;

    const breadcrumbTen = document.getElementById("breadcrumb-ten-banh");
    if (breadcrumbTen) breadcrumbTen.innerText = banh.ten;

    const breadcrumbDanhMuc = document.getElementById("breadcrumb-danh-muc");
    if (breadcrumbDanhMuc) {
        breadcrumbDanhMuc.innerText = banh.tenDanhMuc;
        breadcrumbDanhMuc.href = `products.html?danhMuc=${banh.danhMuc}`;
    }

    const anhChinh = document.getElementById("anh-chinh-san-pham");
    if (anhChinh) {
        anhChinh.src = banh.hinh;
        anhChinh.alt = banh.ten;
    }

    const tenBanh = document.getElementById("chi-tiet-ten-banh");
    if (tenBanh) tenBanh.innerText = banh.ten;

    const maBanh = document.getElementById("chi-tiet-ma-banh");
    if (maBanh) maBanh.innerText = `MSP: SB-${1000 + banh.id}`;

    const tenDm = document.getElementById("chi-tiet-danh-muc");
    if (tenDm) tenDm.innerText = banh.tenDanhMuc;

    const daBan = document.getElementById("chi-tiet-da-ban");
    if (daBan) daBan.innerText = `Đã bán ${banh.daBan} sản phẩm`;

    const giaBanh = document.getElementById("chi-tiet-gia-ban");
    if (giaBanh) giaBanh.innerText = dinhDangTien(banh.gia);

    const giaGocBanh = document.getElementById("chi-tiet-gia-goc");
    if (giaGocBanh) {
        if (banh.giaGoc) {
            giaGocBanh.innerText = dinhDangTien(banh.giaGoc);
            giaGocBanh.style.display = "inline";
        } else {
            giaGocBanh.style.display = "none";
        }
    }

    const tietKiem = document.getElementById("chi-tiet-tiet-kiem");
    if (tietKiem && banh.giaGoc) {
        tietKiem.innerText = `(Tiết kiệm ${dinhDangTien(banh.giaGoc - banh.gia)})`;
        tietKiem.style.display = "inline";
    }

    const moTaNgan = document.getElementById("chi-tiet-mo-ta-ngan");
    if (moTaNgan) moTaNgan.innerText = banh.moTa;

    const moTaChiTiet = document.getElementById("chi-tiet-mo-ta-day-du");
    if (moTaChiTiet) moTaChiTiet.innerText = banh.moTaChiTiet;

    const thanhPhan = document.getElementById("chi-tiet-thanh-phan");
    if (thanhPhan) thanhPhan.innerText = banh.thanhPhan;

    const baoQuan = document.getElementById("chi-tiet-bao-quan");
    if (baoQuan) baoQuan.innerText = banh.baoQuan;

    const kichThuoc = document.getElementById("chi-tiet-kich-thuoc");
    if (kichThuoc) kichThuoc.innerText = banh.kichThuoc;

    const btnThemGio = document.getElementById("btn-them-gio-chi-tiet");
    if (btnThemGio) {
        btnThemGio.onclick = function() {
            const inputSl = document.getElementById("so-luong-chi-tiet");
            const sl = inputSl ? parseInt(inputSl.value) || 1 : 1;
            themVaoGio(banh.id, sl);
        };
    }

    const btnMuaNgay = document.getElementById("btn-mua-ngay-chi-tiet");
    if (btnMuaNgay) {
        btnMuaNgay.onclick = function() {
            const inputSl = document.getElementById("so-luong-chi-tiet");
            const sl = inputSl ? parseInt(inputSl.value) || 1 : 1;
            muaNgay(banh.id, sl);
        };
    }

    const spTuongTu = danhSachBanh.filter(b => b.id !== banh.id && b.danhMuc === banh.danhMuc).slice(0, 3);
    const spLienQuanFallback = spTuongTu.length > 0 ? spTuongTu : danhSachBanh.filter(b => b.id !== banh.id).slice(0, 3);
    hienThiDanhSachBanh(spLienQuanFallback, "danh-sach-sp-lien-quan");
}

function thayDoiSoLuongChiTiet(delta) {
    const inputSl = document.getElementById("so-luong-chi-tiet");
    if (!inputSl) return;
    let sl = parseInt(inputSl.value) || 1;
    sl += delta;
    if (sl < 1) sl = 1;
    if (sl > 99) sl = 99;
    inputSl.value = sl;
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
                <td class="cot-san-pham">
                    <img src="${hinh}" alt="${item.ten}" class="anh-nho">
                    <div class="ten-sp-gio">
                        <a href="product-detail.html?id=${item.id}"><strong>${item.ten}</strong></a>
                        <span class="gia-dong-mobile">${dinhDangTien(item.gia)}</span>
                    </div>
                </td>
                <td class="cot-don-gia">${dinhDangTien(item.gia)}</td>
                <td class="cot-so-luong">
                    <div class="bo-chon-so-luong bo-chon-nho">
                        <button class="nut-tang-giam" onclick="thayDoiSoLuong(${item.id}, -1)">-</button>
                        <span class="so-luong-hien-tai">${item.soLuong}</span>
                        <button class="nut-tang-giam" onclick="thayDoiSoLuong(${item.id}, 1)">+</button>
                    </div>
                </td>
                <td class="cot-thanh-tien"><strong>${dinhDangTien(thanhTien)}</strong></td>
                <td class="cot-thao-tac">
                    <button class="nut-xoa" onclick="xoaKhoiGio(${item.id})" title="Xóa món bánh này">🗑️</button>
                </td>
            </tr>
        `;
    }).join('');

    if (theTongTien) {
        theTongTien.innerText = dinhDangTien(tongTien);
    }
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
    if (confirm("Bạn có chắc chắn muốn xóa món bánh này khỏi giỏ hàng không?")) {
        const gioHang = layGioHang().filter(item => item.id !== idBanh);
        luuGioHang(gioHang);
        hienThiTrangGioHang();
        hienThiToast("Đã xóa bánh khỏi giỏ hàng!");
    }
}

function apDungMaGiamGia() {
    const inputMa = document.getElementById("ma-voucher");
    if (!inputMa) return;
    const ma = inputMa.value.trim().toUpperCase();
    if (!ma) {
        alert("Vui lòng nhập mã giảm giá (Gợi ý: SWEET20 hoặc FREESHIP)");
        return;
    }

    if (ma === "SWEET20") {
        hienThiToast("Áp dụng mã SWEET20 thành công: Giảm 20.000 đ!");
        sessionStorage.setItem("maGiamGia", JSON.stringify({ ma: "SWEET20", giam: 20000 }));
    } else if (ma === "FREESHIP") {
        hienThiToast("Áp dụng mã FREESHIP thành công: Miễn phí vận chuyển!");
        sessionStorage.setItem("maGiamGia", JSON.stringify({ ma: "FREESHIP", giam: 25000, freeship: true }));
    } else {
        alert("Mã giảm giá không hợp lệ hoặc đã hết hạn! Thử mã: SWEET20");
    }
}

function khoiTaoTrangCheckout() {
    const gioHang = layGioHang();
    const theDanhSach = document.getElementById("checkout-danh-sach-mon");
    const theTamTinh = document.getElementById("checkout-tam-tinh");
    const thePhiShip = document.getElementById("checkout-phi-ship");
    const theGiamGia = document.getElementById("checkout-giam-gia");
    const theTongTien = document.getElementById("checkout-tong-tien");

    if (!theDanhSach) return;

    if (gioHang.length === 0) {
        alert("Giỏ hàng của bạn đang trống! Hãy chọn bánh trước khi đặt hàng nhé.");
        window.location.href = "products.html";
        return;
    }

    let tamTinh = 0;
    theDanhSach.innerHTML = gioHang.map(item => {
        const thanhTien = item.gia * item.soLuong;
        tamTinh += thanhTien;
        return `
            <div class="checkout-item">
                <img src="${item.hinh}" alt="${item.ten}" class="checkout-item-img">
                <div class="checkout-item-info">
                    <h4>${item.ten}</h4>
                    <span class="checkout-item-qty">Số lượng: ${item.soLuong} x ${dinhDangTien(item.gia)}</span>
                </div>
                <div class="checkout-item-price">
                    ${dinhDangTien(thanhTien)}
                </div>
            </div>
        `;
    }).join('');

    let phiShip = 20000;
    let giamGia = 0;

    const voucherData = sessionStorage.getItem("maGiamGia");
    if (voucherData) {
        try {
            const v = JSON.parse(voucherData);
            if (v.freeship) {
                phiShip = 0;
            } else if (v.giam) {
                giamGia = v.giam;
            }
        } catch(e){}
    }

    const tongTien = Math.max(0, tamTinh + phiShip - giamGia);

    if (theTamTinh) theTamTinh.innerText = dinhDangTien(tamTinh);
    if (thePhiShip) thePhiShip.innerText = dinhDangTien(phiShip);
    if (theGiamGia) theGiamGia.innerText = `-${dinhDangTien(giamGia)}`;
    if (theTongTien) theTongTien.innerText = dinhDangTien(tongTien);

    const user = layNguoiDungHienTai();
    if (user) {
        const hoTenInput = document.getElementById("dat-hang-hoten");
        const sdtInput = document.getElementById("dat-hang-sdt");
        const emailInput = document.getElementById("dat-hang-email");
        const diachiInput = document.getElementById("dat-hang-diachi");

        if (hoTenInput && !hoTenInput.value) hoTenInput.value = user.hoTen || '';
        if (sdtInput && !sdtInput.value) sdtInput.value = user.sdt || '';
        if (emailInput && !emailInput.value) emailInput.value = user.email || '';
        if (diachiInput && !diachiInput.value) diachiInput.value = user.diaChi || '';
    }
}

function xuLyDatHangCheckout(event) {
    event.preventDefault();

    const gioHang = layGioHang();
    if (gioHang.length === 0) {
        alert("Giỏ hàng đang trống! Vui lòng chọn bánh trước khi đặt hàng.");
        window.location.href = "products.html";
        return;
    }

    const hoTen = document.getElementById("dat-hang-hoten").value.trim();
    const sdt = document.getElementById("dat-hang-sdt").value.trim();
    const email = document.getElementById("dat-hang-email") ? document.getElementById("dat-hang-email").value.trim() : '';
    const diaChi = document.getElementById("dat-hang-diachi").value.trim();
    const ghiChu = document.getElementById("dat-hang-ghichu") ? document.getElementById("dat-hang-ghichu").value.trim() : '';

    const radioPt = document.querySelector('input[name="phuong-thuc-tt"]:checked');
    const phuongThuc = radioPt ? radioPt.value : "COD";
    let tenPt = "Tiền mặt khi nhận bánh (COD)";
    let trangThaiTt = "Chưa thanh toán";

    if (phuongThuc === "QR") {
        tenPt = "Chuyển khoản QR Ngân hàng (VietQR / Momo)";
        trangThaiTt = "Chờ quét mã QR thanh toán";
    } else if (phuongThuc === "ATM") {
        tenPt = "Thẻ ATM / Thẻ tín dụng Visa, Mastercard";
        trangThaiTt = "Đã thanh toán Online";
    }

    let tamTinh = gioHang.reduce((sum, item) => sum + item.gia * item.soLuong, 0);
    let phiShip = 20000;
    let giamGia = 0;

    const voucherData = sessionStorage.getItem("maGiamGia");
    if (voucherData) {
        try {
            const v = JSON.parse(voucherData);
            if (v.freeship) phiShip = 0;
            else if (v.giam) giamGia = v.giam;
        } catch(e){}
    }

    const tongTien = Math.max(0, tamTinh + phiShip - giamGia);

    const maDon = "SB-" + Math.floor(1000 + Math.random() * 9000);
    const bayGio = new Date();
    const ngayDat = `${bayGio.getDate().toString().padStart(2, '0')}/${(bayGio.getMonth()+1).toString().padStart(2, '0')}/${bayGio.getFullYear()} ${bayGio.getHours().toString().padStart(2, '0')}:${bayGio.getMinutes().toString().padStart(2, '0')}`;

    const donHangMoi = {
        maDon: maDon,
        ngayDat: ngayDat,
        hoTen: hoTen,
        sdt: sdt,
        email: email,
        diaChi: diaChi,
        ghiChu: ghiChu,
        phuongThucThanhToan: tenPt,
        trangThaiThanhToan: trangThaiTt,
        trangThaiDon: "Chờ xác nhận & chuẩn bị bánh",
        maTrangThai: 1,
        phiShip: phiShip,
        giamGia: giamGia,
        tamTinh: tamTinh,
        tongTien: tongTien,
        sanPham: [...gioHang]
    };

    const dsDonHang = layDanhSachDonHang();
    dsDonHang.unshift(donHangMoi);
    luuDanhSachDonHang(dsDonHang);

    luuGioHang([]);
    sessionStorage.removeItem("maGiamGia");

    alert(`🎉 ĐẶT HÀNG THÀNH CÔNG!\nCảm ơn bạn: ${hoTen}\nMã đơn hàng của bạn là: ${maDon}\nSweet Bakery sẽ liên hệ và giao bánh trong thời gian sớm nhất!`);
    window.location.href = `order-detail.html?id=${maDon}`;
}

function hienThiTrangLichSuDonHang() {
    const theChua = document.getElementById("danh-sach-don-hang");
    if (!theChua) return;

    const dsDonHang = layDanhSachDonHang();

    if (dsDonHang.length === 0) {
        theChua.innerHTML = `
            <div class="gio-hang-trong">
                <p class="bieu-tuong">📦</p>
                <h3>Bạn chưa có đơn đặt hàng nào!</h3>
                <p>Hãy chọn những chiếc bánh thơm ngon và đặt hàng ngay hôm nay nhé.</p>
                <a href="products.html" class="nut-bam">Khám Phá Bánh Ngon</a>
            </div>
        `;
        return;
    }

    theChua.innerHTML = dsDonHang.map(dh => {
        let classTrangThai = "badge-cho-xac-nhan";
        if (dh.maTrangThai === 2) classTrangThai = "badge-dang-lam";
        else if (dh.maTrangThai === 3) classTrangThai = "badge-dang-giao";
        else if (dh.maTrangThai === 4) classTrangThai = "badge-da-giao";

        const dsAnhSp = (dh.sanPham || []).slice(0, 3).map(sp => `
            <img src="${sp.hinh}" alt="${sp.ten}" class="anh-mini-don" title="${sp.ten} (x${sp.soLuong})">
        `).join('');

        const demSpConLai = (dh.sanPham || []).length > 3 ? `<span class="them-sp">+${dh.sanPham.length - 3} món khác</span>` : '';

        return `
            <div class="the-don-hang">
                <div class="dau-the-don">
                    <div class="ma-va-ngay">
                        <span class="ma-don">Mã: <strong>#${dh.maDon}</strong></span>
                        <span class="ngay-dat">📅 ${dh.ngayDat}</span>
                    </div>
                    <span class="badge-trang-thai ${classTrangThai}">${dh.trangThaiDon}</span>
                </div>

                <div class="than-the-don">
                    <div class="hinh-san-pham-don">
                        ${dsAnhSp}
                        ${demSpConLai}
                    </div>
                    <div class="thong-tin-nhan-don">
                        <p><strong>Người nhận:</strong> ${dh.hoTen} (${dh.sdt})</p>
                        <p><strong>Địa chỉ:</strong> ${dh.diaChi}</p>
                        <p><strong>Thanh toán:</strong> ${dh.phuongThucThanhToan}</p>
                    </div>
                </div>

                <div class="chan-the-don">
                    <div class="tong-tien-don">
                        <span>Tổng tiền: </span>
                        <strong>${dinhDangTien(dh.tongTien)}</strong>
                    </div>
                    <div class="nhom-nut-don">
                        <a href="order-detail.html?id=${dh.maDon}" class="nut-bam nut-bam-phu">Xem Chi Tiết Đơn</a>
                        <a href="products.html" class="nut-bam">Mua Lại</a>
                    </div>
                </div>
            </div>
        `;
    }).join('');
}

function hienThiTrangChiTietDonHang() {
    const maDonParam = layThamSoUrl("id");
    const dsDonHang = layDanhSachDonHang();

    let donHang = null;
    if (maDonParam) {
        donHang = dsDonHang.find(d => d.maDon.toUpperCase() === maDonParam.toUpperCase());
    }

    if (!donHang && dsDonHang.length > 0) {
        donHang = dsDonHang[0];
    }

    if (!donHang) {
        alert("Không tìm thấy thông tin đơn hàng!");
        window.location.href = "order-history.html";
        return;
    }

    const theMa = document.getElementById("od-ma-don");
    if (theMa) theMa.innerText = `#${donHang.maDon}`;

    const theNgay = document.getElementById("od-ngay-dat");
    if (theNgay) theNgay.innerText = donHang.ngayDat;

    const theTrangThai = document.getElementById("od-trang-thai");
    if (theTrangThai) theTrangThai.innerText = donHang.trangThaiDon;

    capNhatTimelineDonHang(donHang.maTrangThai || 1);

    const theHoTen = document.getElementById("od-ho-ten");
    if (theHoTen) theHoTen.innerText = donHang.hoTen;

    const theSdt = document.getElementById("od-sdt");
    if (theSdt) theSdt.innerText = donHang.sdt;

    const theEmail = document.getElementById("od-email");
    if (theEmail) theEmail.innerText = donHang.email || "Chưa cung cấp";

    const theDiaChi = document.getElementById("od-dia-chi");
    if (theDiaChi) theDiaChi.innerText = donHang.diaChi;

    const theGhiChu = document.getElementById("od-ghi-chu");
    if (theGhiChu) theGhiChu.innerText = donHang.ghiChu || "Không có ghi chú thêm";

    const thePhuongThuc = document.getElementById("od-phuong-thuc");
    if (thePhuongThuc) thePhuongThuc.innerText = donHang.phuongThucThanhToan;

    const theTtThanhToan = document.getElementById("od-tt-thanh-toan");
    if (theTtThanhToan) theTtThanhToan.innerText = donHang.trangThaiThanhToan;

    const theBangBody = document.getElementById("od-bang-san-pham");
    if (theBangBody && donHang.sanPham) {
        theBangBody.innerHTML = donHang.sanPham.map(sp => `
            <tr>
                <td class="cot-san-pham">
                    <img src="${sp.hinh}" alt="${sp.ten}" class="anh-nho">
                    <a href="product-detail.html?id=${sp.id}"><strong>${sp.ten}</strong></a>
                </td>
                <td>${dinhDangTien(sp.gia)}</td>
                <td>${sp.soLuong}</td>
                <td><strong>${dinhDangTien(sp.gia * sp.soLuong)}</strong></td>
            </tr>
        `).join('');
    }

    const theTamTinh = document.getElementById("od-tam-tinh");
    if (theTamTinh) theTamTinh.innerText = dinhDangTien(donHang.tamTinh);

    const thePhiShip = document.getElementById("od-phi-ship");
    if (thePhiShip) thePhiShip.innerText = dinhDangTien(donHang.phiShip);

    const theGiamGia = document.getElementById("od-giam-gia");
    if (theGiamGia) theGiamGia.innerText = `-${dinhDangTien(donHang.giamGia)}`;

    const theTongTien = document.getElementById("od-tong-tien");
    if (theTongTien) theTongTien.innerText = dinhDangTien(donHang.tongTien);
}

function capNhatTimelineDonHang(stepNumber) {
    const steps = [1, 2, 3, 4];
    steps.forEach(i => {
        const stepEl = document.getElementById(`step-${i}`);
        if (!stepEl) return;
        if (i < stepNumber) {
            stepEl.className = "timeline-step step-completed";
        } else if (i === stepNumber) {
            stepEl.className = "timeline-step step-active";
        } else {
            stepEl.className = "timeline-step";
        }
    });
}

function xuLyDangNhap(event) {
    event.preventDefault();
    const email = document.getElementById("login-email").value.trim();
    const pass = document.getElementById("login-password").value.trim();

    if (!email || !pass) {
        alert("Vui lòng nhập đầy đủ Email và Mật khẩu!");
        return;
    }

    let hoTen = "Khách Hàng Thân Thiết";
    if (email.includes("@")) {
        const phanDau = email.split("@")[0];
        hoTen = phanDau.charAt(0).toUpperCase() + phanDau.slice(1);
    }

    const userMoi = {
        email: email,
        hoTen: hoTen,
        sdt: "0912345678",
        diaChi: "Quận 1, TP. Hồ Chí Minh"
    };

    luuNguoiDungHienTai(userMoi);
    alert(`🎉 Đăng nhập thành công! Chào mừng ${hoTen} quay trở lại với Sweet Bakery.`);
    window.location.href = "index.html";
}

function xuLyDangKy(event) {
    event.preventDefault();
    const hoTen = document.getElementById("reg-hoten").value.trim();
    const email = document.getElementById("reg-email").value.trim();
    const sdt = document.getElementById("reg-sdt").value.trim();
    const pass = document.getElementById("reg-pass").value;
    const confirmPass = document.getElementById("reg-confirm-pass").value;

    if (!hoTen || !email || !sdt || !pass) {
        alert("Vui lòng điền đầy đủ các thông tin đăng ký!");
        return;
    }

    if (pass !== confirmPass) {
        alert("Mật khẩu xác nhận không khớp! Vui lòng kiểm tra lại.");
        return;
    }

    if (pass.length < 6) {
        alert("Mật khẩu cần tối thiểu 6 ký tự để đảm bảo an toàn!");
        return;
    }

    const userMoi = {
        hoTen: hoTen,
        email: email,
        sdt: sdt,
        diaChi: "TP. Hồ Chí Minh"
    };

    luuNguoiDungHienTai(userMoi);
    alert(`🎉 Chúc mừng ${hoTen}! Đăng ký tài khoản thành công. Bạn đã tự động đăng nhập.`);
    window.location.href = "index.html";
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

    alert(`Cảm ơn bạn: ${ten}! Sweet Bakery đã tiếp nhận tin nhắn và sẽ liên hệ lại sớm nhất.`);
    document.getElementById("form-lien-he").reset();
}

window.onload = function() {
    capNhatSoLuongHeader();
    capNhatGiaoDienTaiKhoan();
    khoiTaoDonHangMau();

    if (document.getElementById("danh-sach-trang-chu")) {
        hienThiDanhSachBanh(danhSachBanh.slice(0, 4), "danh-sach-trang-chu");
    }

    if (document.getElementById("khung-trang-san-pham")) {
        khoiTaoTrangSanPham();
    }

    if (document.getElementById("khung-chi-tiet-san-pham")) {
        hienThiTrangChiTietSanPham();
    }

    if (document.getElementById("bang-gio-hang-body")) {
        hienThiTrangGioHang();
    }

    if (document.getElementById("khung-trang-checkout")) {
        khoiTaoTrangCheckout();
    }

    if (document.getElementById("danh-sach-don-hang")) {
        hienThiTrangLichSuDonHang();
    }

    if (document.getElementById("khung-chi-tiet-don-hang")) {
        hienThiTrangChiTietDonHang();
    }
};
