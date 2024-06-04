let ItemId = document.getElementById("ItemId");
let ProductId = document.getElementById("ProductId");
let quntity = document.getElementById("quntity");
let Price = document.getElementById("Price");
let discount = document.getElementById("discount");

var resourceStrings = {};
    $(document).ready(function () {
        $.ajax({
            url: '/Resource/GetResourceStrings',
            method: 'GET',
            success: function (data) {
                resourceStrings = data;
            },
            error: function () {
                console.error('Error loading resource strings');
            }
        });
       ShowTable();
       GetAllTotal();
   
    $('#ItemId').change(function () {
              
                var categoryId = $(this).val();
    if (categoryId == "") {
        $('#ProductId').html(`<option value="">اختر الفئة</option>`);
    console.log("impty");
                    }
    else {
        $.ajax({
            url: '/Invoice/GetProductsByCategory/' + ItemId.value,
                         
        type: 'GET',
    data: {categoryId: categoryId },
    success: function (products) {
        console.log(products)
                            var productSelect = $('#ProductId');
    productSelect.empty();
    productSelect.append($('<option />', {
        value: '',
    text: '-- اختراسم الصنف --'
                            }));
    $.each(products, function (index, product) {
        productSelect.append($('<option/>', {
            value: product.Id,
            text: product.Name

        }));
                            });
                        },
    error: function () {
        alert('Error retrieving products.');
                        }
                    });
                }
            });



    $('#ProductId').change(function () {
                var productId = $(this).val();

    console.log(productId)

    $.ajax({

        url: '/Invoice/GetProductPice/' + ProductId.value,

  
    type: 'GET',
    cache: false,
    data: {productId: productId },


    success: function (result) {

        $('#Price').val(result.Price);
                        } 
                    },

    );
            }

    );
    });




SaveProducts = () => {

        let objPrduct = {

            ProductId: ProductId.value,
            ItemId: ItemId.value,
            Price: Price.value,
            Quentit: quntity.value,
            Discount: discount.value,
            Total: (Price.value * quntity.value) -(discount.value),
           
                
    };
   
  
  
    $.ajax({
    url: '/Invoice/InvoiceTemp',
    method: 'POST',
    cache: false,
    data:objPrduct,
    success: (data) => {

        
         ResetData();
   ShowTable();
       GetAllTotal(); 
                }

            });

        };
ResetData = () => {
  
    ItemId.value = '';
    ProductId.value = '';
    quntity.value = 1;
    Price.value = 0;
    discount.value = 0;
};

ShowTable = () => {
  
   
    $.ajax({

        url: '/Invoice/InvoiceTemp',
        method: 'GET',
        cache: false,
       
        success: (data) => {
          
            let Table = '';

            for (x in data) {

                Table += `
                  <tr>
                   <td class="col-1">#</td>

                    <td>${data[x].Item.Name}</td>
                   <td>${data[x].Product.Name}</td>
                    <td>${data[x].Price}</td>
                   <td>${data[x].Quentit}</td>
                   <td>${data[x].Discount}</td>
                    <td>${data[x].Total}</td>
                    <td><a class="btn btn-danger" onclick="DeleteProduct(${data[x].InvoiceId})"  style="color:#ffff"><i class="fa fa-trash"></i></a></td>
    
                  </tr>`;
            }
            $('#tablebody').html(Table);
        }
    });
   
};

DeleteProduct = (id) => {
     Swal.fire({
        

         title: resourceStrings.titleMsg,
         text: resourceStrings.textMsg,
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#d33",
            cancelButtonColor: "#3085d6",
         cancelButtonText: resourceStrings.cancel,
         confirmButtonText: resourceStrings.lbconfirmButtonText,
    }).then((result) => {
        if (result.isConfirmed) {
            
            $.ajax({
                url: `/Invoice/deleteInvoiceTemp/${id}`,
                type: 'POST',
                success: function (response) {
                    if (response.success) {
                        Swal.fire(
                            resourceStrings.textMsg,
                            resourceStrings.ItemDeleted,
                            resourceStrings.success,
                        ).then(() => {
                          
                            location.reload();
                            GetAllTotal();
                        });
                    } else {
                        Swal.fire(
                            'Oooops...',
                            'Something went wrong.',
                            'error'
                        );
                    }
                }
            });
        }
    });


   } ;





GetAllTotal = () => {
    $.ajax({
        url: `/Invoice/GetAllTotal`,
        method: 'GET',
        cache: false,
        success: (data) => {
          
            $('#allTotal').val(data);
            $('#afterDescount').val(data);

        }
    })
}
Discount = () => {

    $('#afterDescount').val($('#allTotal').val() - $('#discountTotal').val());
};

document.getElementById("discountTotal").addEventListener('change', Discount);
document.getElementById("discountTotal").addEventListener('keyup', Discount);