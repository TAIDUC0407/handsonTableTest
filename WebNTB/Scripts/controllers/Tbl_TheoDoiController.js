var Tbl_TheoDoiController = {
    init: function () {
        Tbl_TheoDoiController.loadData();
        
    },
    registerEvent: function () {
        $('.txtSalary').off('keypress').on('keypress', function (e) {
            if (e.which == 13)
            {
                if ($(this).hasClass('s2'))
                {
                    var idTH = $(this).attr('data-idTH');
                    var value = $(this).val();
                    Tbl_TheoDoiController.updateThucHien(idTH, value);
                }
                else if ($(this).hasClass('s1'))
                {
                    var idSLKH = $(this).attr('data-idSLKH');
                    var value = $(this).val();
                    Tbl_TheoDoiController.updateSLKeHoach(idSLKH, value);
                }
                else if ($(this).hasClass('s3'))
                {
                    var idLKTH = $(this).attr('data-idLKTH');
                    var value = $(this).val();
                    Tbl_TheoDoiController.updateLKThucHien(idLKTH, value);
                }

                
            }
        });
    },

    updateThucHien: function (id, value) {
        var data = { MaChuyen: id, ThucHien: value};
        $.ajax({
            url: '/Tbl_TheoDoi/Update',
            type: 'POST',
            dataType: 'json',
            data: { model: JSON.stringify(data) },
            success: function (response) {
                if (response.status) {
                    alert(" Update salary success !")
                }
                else
                    alert(" Update salary failed !")

            }
        })
    },

    updateSLKeHoach: function (id, value) {
        var data = { MaChuyen: id, SLKeHoach: value };
        $.ajax({
            url: '/Tbl_TheoDoi/Update',
            type: 'POST',
            dataType: 'json',
            data: { model: JSON.stringify(data) },
            success: function (response) {
                if (response.status) {
                    alert(" Update salary success !")
                }
                else
                    alert(" Update salary failed !")

            }
        })
    },

    updateLKThucHien: function (id, value) {
        var data = { MaChuyen: id, LuyKeThucHien: value };
        $.ajax({
            url: '/Tbl_TheoDoi/Update',
            type: 'POST',
            dataType: 'json',
            data: { model: JSON.stringify(data) },
            success: function (response) {
                if (response.status) {
                    alert(" Update salary success !")
                }
                else
                    alert(" Update salary failed !")

            }
        })
    },



    loadData: function () {
        $.ajax({
            url: '/Tbl_TheoDoi/LoadData',
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    var data = response.data;
                    var html = '';
                    var template = $('#data-template').html();
                    $.each(data, function (i, item) {

                        var date = new Date(parseInt(item.NgayTao.substr(6)));
                        var datetime = date.getDate() + "/" + (date.getMonth() + 1) + "/" + date.getFullYear();

                        html += Mustache.render(template, {
                            MaChuyen: item.MaChuyen,
                            MaHang: item.MaHang,
                            SLKeHoach: item.SLKeHoach,
                            ThucHien: item.ThucHien,
                            LuyKeThucHien: item.LuyKeThucHien,
                            DenBaoCapBTP: item.DenBaoCapBTP == true ? "<span class=\"label label-success\">Active</span>" : "<span class=\"label label-danger\">Block</span>",
                            NgayTao: datetime
                        })
                    });
                    $('#tblData').html(html);
                    Tbl_TheoDoiController.registerEvent();
                }
                    
            }
        })
    }
}
 Tbl_TheoDoiController.init();