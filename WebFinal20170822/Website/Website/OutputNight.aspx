<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OutputNight.aspx.cs" Inherits="Website.OutputNight" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="stylesheet" href="../layout/styles/layout.css" type="text/css" />
    <meta http-equiv="refresh" content="12" />
    <title>Output form night </title>

    <%-- fixed Header Gridview with multi header  --%>
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="js/gridviewScroll.js"></script>
    <link href="layout/styles/GridviewScroll.css" rel="stylesheet" />


    <%-- Time System --%>
    <script type="text/javascript">
        function time() {
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
                        <asp:LinkButton runat="server" ID="lbtInputForm" OnClick="lbtInputForm_Click" CausesValidation="false">Input form</asp:LinkButton></li>
                    <li>
                        <asp:LinkButton runat="server" ID="lbtnExport" OnClick="lbtnExport_Click" CausesValidation="false">Export Excel</asp:LinkButton></li>
                    <li>
                        <asp:LinkButton runat="server" ID="lbtnHistory" Width="70px " OnClick="lbtnHistory_Click" CausesValidation="false">View History </asp:LinkButton></li> 
                    <li>
                        <asp:DropDownList runat="server" ID="ddlShift" Width="140px" CssClass="ddlShift" BorderWidth="1px" BackColor="#0291d0" ForeColor="White" Height="25px" OnSelectedIndexChanged="ddlShift_SelectedIndexChanged" AutoPostBack="True" Font-Bold="true">
                            <asp:ListItem Value="Day">Work Shift : Day</asp:ListItem>
                            <asp:ListItem Value="Night" Selected="True">Work Shift : Night</asp:ListItem>
                        </asp:DropDownList>
                    </li>
                </ul>
            </div>
            <div id="search">
                <fieldset>
                    <legend>Date Time</legend>
                    <div id="clock" style="margin-top: 10px"></div>
                </fieldset>
            </div>
            <br class="clear" />
        </div>
    </div>
    
    <div id="content" style="width: 100%; color: black;  height: 500px; margin-top: 10px; margin-left: 2px">
        <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                 OnRowDataBound="GridView1_RowDataBound" ShowFooter="true" CellSpacing="0" Font-Size="10">
                <HeaderStyle HorizontalAlign="Center" CssClass="GridviewScrollHeader" Font-Bold="true" Font-Size="Smaller" Height="30px" />
                <FooterStyle BackColor="White" ForeColor="#000099" HorizontalAlign="Center" Font-Bold="true" Font-Size="9" Height="25"/>
                <Columns>
                    <asp:BoundField DataField="LineName" HeaderText="L">
                        <ItemStyle Width="23px" HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="Rank" HeaderText="Rank">
                        <ItemStyle Width="35px" HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField HeaderText="Model" DataField="Model">
                        <ItemStyle Width="145px" HorizontalAlign="Left" Font-Size="10"></ItemStyle>
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
                        <ItemStyle HorizontalAlign="Center" Width="50px" />
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
                    <asp:BoundField HeaderText="19H" DataField="H19">
                        <ItemStyle HorizontalAlign="Center" Width="48px" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="20H" DataField="H20">
                        <ItemStyle HorizontalAlign="Center" Width="48px" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="21H" DataField="H21">
                        <ItemStyle HorizontalAlign="Center" Width="48px" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="22H" DataField="H22">
                        <ItemStyle HorizontalAlign="Center" Width="48px" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="23H" DataField="H23">
                        <ItemStyle HorizontalAlign="Center" Width="48px" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="0H" DataField="H00">
                        <ItemStyle HorizontalAlign="Center" Width="48px" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="01H" DataField="H01">
                        <ItemStyle HorizontalAlign="Center" Width="48px" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="02H" DataField="H02">
                        <ItemStyle HorizontalAlign="Center" Width="48px" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="03H" DataField="H03">
                        <ItemStyle HorizontalAlign="Center" Width="48px" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="04H" DataField="H04">
                        <ItemStyle HorizontalAlign="Center" Width="48px" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="05H" DataField="H05">
                        <ItemStyle HorizontalAlign="Center" Width="48px" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="06H" DataField="H06">
                        <ItemStyle HorizontalAlign="Center" Width="48px" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Status" DataField="Status">
                        <ItemStyle HorizontalAlign="Center" Width="45px" Font-Bold="true" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </asp:Panel>    
    </div>
    </form>

    <script type="text/javascript">
        $(document).ready(function () {
            gridviewScroll();
            setInterval(function () {
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
                    barsize: 0,
                    startVertical: 300
                });
            }, 6000);
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
                barsize: 0,
            });
        }
	</script>
</body>
</html>

