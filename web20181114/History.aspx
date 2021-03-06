﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="Website.History" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="../layout/styles/layout.css" type="text/css" />
    <script type="text/javascript" src="js/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="js/jquery-ui.js"></script>
    <link rel="stylesheet" href="js/jquery-ui.css" />
    <title>History</title>

   <%-- fixed Header Gridview with multi header  --%>
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="js/gridviewScroll.js"></script>
    <link href="layout/styles/GridviewScroll.css" rel="stylesheet" />

    <%-- Time System  --%>
    <script type="text/javascript">
        //Time System
        function time() {
            $(function () {
                $("#datepicker").datepicker({
                    dateFormat: 'dd/mm/yy',
                    maxDate: 0,
                });

                $(".ui-datepicker-trigger").mouseover(function () {
                    $(this).css('cursor', 'pointer');
                });
            });
            var today = new Date();
            var weekday = new Array(7);
            weekday[0] = "Sunday";
            weekday[1] = "Monday";
            weekday[2] = "Tuesday";
            weekday[3] = "Wednesday";
            weekday[4] = "Thursday";
            weekday[5] = "Friday";
            weekday[6] = "Saturday";
            var day = weekday[today.getDay()];
            var dd = today.getDate();
            var mm = today.getMonth() + 1; //January is 0!
            var yyyy = today.getFullYear();
            var h = today.getHours();
            var m = today.getMinutes();
            var s = today.getSeconds();
            m = checkTime(m);
            s = checkTime(s);
            nowTime = h + ":" + m + ":" + s;
            if (dd < 10) { dd = '0' + dd } if (mm < 10) { mm = '0' + mm } today = day + ', ' + dd + '/' + mm + '/' + yyyy;

            tmp = '<span class="date">' + today + ' | ' + nowTime + '</span>';

            document.getElementById("clock").innerHTML = tmp;

            clocktime = setTimeout("time()", "1000", "JavaScript");
            function checkTime(i) {
                if (i < 10) {
                    i = "0" + i;
                }
                return i;
            }
        }
    </script>
</head>

<body onload="time()" style="background-color: white">
    <form id="form1" runat="server">
        <div class="wrapper col2">
            <div id="topbar">
                <div id="topnav">
                    <ul>
                        <li>
                            <asp:LinkButton runat="server" ID="lbtInputForm" OnClick="lbtInputForm_Click" CausesValidation="false">Home Page</asp:LinkButton></li>
                        <li>
                            <asp:LinkButton runat="server" ID="lbtn" OnClick="lbtnExport_Click" CausesValidation="false">Export Excel</asp:LinkButton></li>
                        <li>
                            <asp:DropDownList runat="server" ID="ddlShift" Width="140px" CssClass="ddlShift" BorderWidth="1px" BackColor="#0291d0" ForeColor="White" Height="25px" OnSelectedIndexChanged="ddlShift_SelectedIndexChanged" AutoPostBack="True" Font-Bold="true">
                                <asp:ListItem Value="Day" Selected="True">Work Shift : Day</asp:ListItem>
                                <asp:ListItem Value="Night">Work Shift : Night</asp:ListItem>
                            </asp:DropDownList>
                        </li>
                    </ul>
                </div>
                <div id="search">
                    <fieldset>
                        <legend>Date Time</legend>
                        <div id="clock" style="width: 200px"></div>
                    </fieldset>
                </div>
                <br class="clear" />
            </div>
        </div>

        <div style="margin-top: 5px; margin-bottom: 5px">
            <div style="width: 30%; margin-left: 20%;">
                <asp:TextBox ID="datepicker" runat="server"></asp:TextBox>
                <asp:Button ID="btnView" runat="server" Text="Show" OnClick="btnView_Click" />
            </div>
        </div>
        
        <div id="content" style="width: 100%; color: black; height: 500px; margin-top: 10px;">
            <asp:ScriptManager ID="ScriptManager1" runat="server"
                EnablePageMethods="true">
            </asp:ScriptManager>      
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderColor="#333333" ForeColor="Black" OnRowDataBound="GridView1_RowDataBound" ShowFooter="true" CellSpacing="0" Font-Size="11" RowStyle-Wrap="true">
                    <HeaderStyle CssClass="GridviewScrollHeader" HorizontalAlign="Center" Font-Size="Smaller" />
                    <FooterStyle BackColor="White" ForeColor="#000099" HorizontalAlign="Center" Font-Bold="true" Font-Size="9" Height="30"/>
                    <Columns>
                        <asp:BoundField DataField="LineName" HeaderText="L"  >
                            <ItemStyle Width="23px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField DataField="Rank" HeaderText="Rank">
                            <ItemStyle Width="35px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField HeaderText="Model" DataField="Model">
                            <ItemStyle Width="145px" HorizontalAlign="Left" Font-Size="Smaller"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField DataField="ChangeModel" HeaderText="C.M">
                            <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField HeaderText="P.W" DataField="Planed_Worker">
                            <ItemStyle Width="35px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField HeaderText="A.W" DataField="Actual_Worker">
                            <ItemStyle HorizontalAlign="Center" Width="35px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Plan" DataField="Plan">
                            <ItemStyle HorizontalAlign="Center" Width="50px"  />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Actual" DataField="Actual">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Diff" DataField="Diff">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Target" DataField="Target">
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="A.R">
                            <ItemTemplate>
                                <asp:Label ID="lblArchived_Rate" runat="server" Width="55px" Text='<%# Eval("Archived_Rate") +"%" %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"/>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="07H" DataField="H07">
                            <ItemStyle HorizontalAlign="Center" Width="48px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="08H" DataField="H08">
                            <ItemStyle HorizontalAlign="Center" Width="48px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="09H" DataField="H09">
                            <ItemStyle HorizontalAlign="Center" Width="48px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="10H" DataField="H10">
                            <ItemStyle HorizontalAlign="Center" Width="48px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="11H" DataField="H11">
                            <ItemStyle HorizontalAlign="Center" Width="48px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="12H" DataField="H12">
                            <ItemStyle HorizontalAlign="Center" Width="48px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="13H" DataField="H13">
                            <ItemStyle HorizontalAlign="Center" Width="48px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="14H" DataField="H14">
                            <ItemStyle HorizontalAlign="Center" Width="48px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="15H" DataField="H15">
                            <ItemStyle HorizontalAlign="Center" Width="48px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="16H" DataField="H16">
                            <ItemStyle HorizontalAlign="Center" Width="48px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="17H" DataField="H17">
                            <ItemStyle HorizontalAlign="Center" Width="48px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="18H" DataField="H18">
                            <ItemStyle HorizontalAlign="Center" Width="48px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Status" DataField="Status">
                            <ItemStyle HorizontalAlign="Center" Width="45px" Font-Bold="true" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
        </div>
    </form>

    <script type="text/javascript">
        $(document).ready(function () {
            gridviewScroll();
        });

        function gridviewScroll() {
            gridView1 = $('#GridView1').gridviewScroll({
                width: 1260,
                height: $(window).height() - 100,
                railcolor: "#F0F0F0",
                barcolor: "#CDCDCD",
                barhovercolor: "#606060",
                bgcolor: "#F0F0F0",
                freezesize: 1,
                headerrowcount: 1,
                railsize: 0,
                barsize: 0
            });
        }
	</script>
</body>
</html>
