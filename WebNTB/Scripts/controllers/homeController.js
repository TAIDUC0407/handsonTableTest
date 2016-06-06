var homeController = {
    init: function () {
        homeController.loadData();
        
    },
    registerEvent: function () {
        $('.txtSalary').off('keypress').on('keypress', function (e) {
            if (e.which == 13)
            {
                var id = $(this).data('id');
                var value = $(this).val();

                homeController.updateSalary(id,value);
            }
        });
    },

    updateSalary: function (id, value) {
        var data = { ID: id, Salary: value };
        $.ajax({
            url: '/Home/Update',
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
            url: '/Home/LoadData',
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    var data = response.data;
                    var html = '';
                    var template = $('#data-template').html();
                    $.each(data, function (i, item) {
                        //alert(item.Status)
                        html += Mustache.render(template, {
                            ID: item.ID,
                            Name: item.Name,
                            Salary: item.Salary,
                            Status: item.Status ==true ? "<span class=\"label label-success\">Active</span>":"<span class=\"label label-danger\">Block</span>"
                        })
                    });
                    $('#tblData').html(html);
                    homeController.registerEvent();
                }
                    
            }
        })
    }
}
 homeController.init();