$(document).ready(function () {
            var counter = 0;

            $("#addrow").on("click", function () {
                var newRow = $("<tr>");
                var cols = "";

				cols += '<td> '+ (counter + 2) +' </td>';
                cols += '<td><input type="text" class="form-control" name="Medicine' + counter + '"/></td>';
                cols += '<td><input type="text" class="form-control" name="Description' + counter + '"/></td>';
                cols += '<td><input type="text" class="form-control" name="Dosage' + counter + '"/></td>';
				cols += '<td><input type="text" class="form-control" name="Qty' + counter + '"/></td>';
				cols += '<td><a id="addrow"class="text-success font-18" title="Add"><i class="fa fa-plus"></i></a></td>';
				
                cols += '<td><input type="button" class="ibtnDel btn btn-md btn-danger "  value="Delete"></td>';
                newRow.append(cols);
                $("table.order-list").append(newRow);
                counter++;
            });
			



            $("table.order-list").on("click", ".ibtnDel", function (event) {
                $(this).closest("tr").remove();
                counter -= 1
            });


        });



        function calculateRow(row) {
            var price = +row.find('input[name^="price"]').val();

        }

        function calculateGrandTotal() {
            var grandTotal = 0;
            $("table.order-list").find('input[name^="price"]').each(function () {
                grandTotal += +$(this).val();
            });
            $("#grandtotal").text(grandTotal.toFixed(2));
        }