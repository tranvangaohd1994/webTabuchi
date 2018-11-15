<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeActualInputNight.aspx.cs" Inherits="Website.ChangeActualInputNight" EnableEventValidation="false" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Change Actual by Hour (Night)</title>
    <link rel="stylesheet" href="../layout/styles/layout.css" type="text/css" />
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <style type="text/css">
        .hover_row {
            background-color: #FFFFBF;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $("[id*=GridView1] td").hover(function () {
                $("td", $(this).closest("tr")).addClass("hover_row");
            }, function () {
                $("td", $(this).closest("tr")).removeClass("hover_row");
            });
        });
    </script>
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
                            <asp:LinkButton runat="server" ID="lbtHome" OnClick="lbtHome_Click" CausesValidation="false" >Home</asp:LinkButton></li>
                        <li>
                            <asp:LinkButton runat="server" ID="lbtInputForm" OnClick="lbtInputForm_Click" CausesValidation="false" >Input Page</asp:LinkButton></li>
                        <li>
                            <asp:DropDownList runat="server" ID="ddlShift" Width="140px" CssClass="ddlShift" BorderWidth="1px" BackColor="#0291d0" ForeColor="White" Height="25px" OnSelectedIndexChanged="ddlShift_SelectedIndexChanged" AutoPostBack="True" Font-Bold="true">
                                <asp:ListItem Value="Day" >Work Shift : Day</asp:ListItem>
                                <asp:ListItem Value="Night" Selected="True">Work Shift : Night</asp:ListItem>
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

        <div id="content" style="width: 100%; color: black; height: 1000px">
            <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" style="margin-left: 50px"  >
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderColor="#333333" OnRowDataBound="GridView1_RowDataBound" ShowFooter="true" CellSpacing="0" CellPadding="0" Font-Size="11" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <HeaderStyle HorizontalAlign="Center" Font-Size="Smaller" Height="30px" BackColor="#EFEFEF"/>
                    <FooterStyle BackColor="White" ForeColor="#000099" HorizontalAlign="Center" Font-Bold="true" />
                    <Columns>
                        <asp:BoundField DataField="LineName" HeaderText="Line">
                            <ItemStyle Width="40px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField DataField="Rank" HeaderText="Rank">
                            <ItemStyle Width="40px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField HeaderText="Model" DataField="Model">
                            <ItemStyle Width="140px" HorizontalAlign="Left" Font-Size="Smaller"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField DataField="ChangeModel" HeaderText="C.M">
                            <ItemStyle Width="40px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Plan" DataField="Plan">
                            <ItemStyle HorizontalAlign="Center" Width="45px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Actual" DataField="Actual">
                            <ItemStyle HorizontalAlign="Center" Width="45px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Diff" DataField="Diff">
                            <ItemStyle HorizontalAlign="Center" Width="45px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Target" DataField="Target">
                            <ItemStyle HorizontalAlign="Center" Width="45px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="A.R">
                            <ItemTemplate>
                                <asp:Label ID="lblArchived_Rate" runat="server" Width="35px" Text='<%# Eval("Archived_Rate") +"%" %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="37px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="19H">
                            <ItemTemplate>
                                <asp:Label ID="lbl19H" runat="server" Width="40px" Text='<%# Bind("H19") %>'></asp:Label>
                                <asp:TextBox ID="txt19H" runat="server" Width="40px" Text='<%# Bind("H19") %>' Visible="false"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="45px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="20H">
                            <ItemTemplate>
                                <asp:Label ID="lbl20H" runat="server" Width="40px" Text='<%# Bind("H20") %>'></asp:Label>
                                <asp:TextBox ID="txt20H" runat="server" Width="40px" Text='<%# Bind("H20") %>' Visible="false"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="45px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="21H">
                            <ItemTemplate>
                                <asp:Label ID="lbl21H" runat="server" Width="40px" Text='<%# Bind("H21") %>'></asp:Label>
                                <asp:TextBox ID="txt21H" runat="server" Width="40px" Text='<%# Bind("H21") %>' Visible="false"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="45px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="22H">
                            <ItemTemplate>
                                <asp:Label ID="lbl22H" runat="server" Width="40px" Text='<%# Bind("H22") %>'></asp:Label>
                                <asp:TextBox ID="txt22H" runat="server" Width="40px" Text='<%# Bind("H22") %>' Visible="false"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="45px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="23H">
                            <ItemTemplate>
                                <asp:Label ID="lbl23H" runat="server" Width="40px" Text='<%# Bind("H23") %>'></asp:Label>
                                <asp:TextBox ID="txt23H" runat="server" Width="40px" Text='<%# Bind("H23") %>' Visible="false"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="45px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="0H">
                            <ItemTemplate>
                                <asp:Label ID="lbl00H" runat="server" Width="40px" Text='<%# Bind("H00") %>'></asp:Label>
                                <asp:TextBox ID="txt00H" runat="server" Width="40px" Text='<%# Bind("H00") %>' Visible="false"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="45px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="01H">
                            <ItemTemplate>
                                <asp:Label ID="lbl01H" runat="server" Width="40px" Text='<%# Bind("H01") %>'></asp:Label>
                                <asp:TextBox ID="txt01H" runat="server" Width="40px" Text='<%# Bind("H01") %>' Visible="false"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="45px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="02H">
                            <ItemTemplate>
                                <asp:Label ID="lbl02H" runat="server" Width="40px" Text='<%# Bind("H02") %>'></asp:Label>
                                <asp:TextBox ID="txt02H" runat="server" Width="40px" Text='<%# Bind("H02") %>' Visible="false"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="45px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="03H">
                            <ItemTemplate>
                                <asp:Label ID="lbl03H" runat="server" Width="40px" Text='<%# Bind("H03") %>'></asp:Label>
                                <asp:TextBox ID="txt03H" runat="server" Width="40px" Text='<%# Bind("H03") %>' Visible="false"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="45px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="04H">
                            <ItemTemplate>
                                <asp:Label ID="lbl04H" runat="server" Width="40px" Text='<%# Bind("H04") %>'></asp:Label>
                                <asp:TextBox ID="txt04H" runat="server" Width="40px" Text='<%# Bind("H04") %>' Visible="false"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="45px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="05H">
                            <ItemTemplate>
                                <asp:Label ID="lbl05H" runat="server" Width="40px" Text='<%# Bind("H05") %>'></asp:Label>
                                <asp:TextBox ID="txt05H" runat="server" Width="40px" Text='<%# Bind("H05") %>' Visible="false"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="45px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="06H">
                            <ItemTemplate>
                                <asp:Label ID="lbl06H" runat="server" Width="40px" Text='<%# Bind("H06") %>'></asp:Label>
                                <asp:TextBox ID="txt06H" runat="server" Width="40px" Text='<%# Bind("H06") %>' Visible="false"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="45px" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Status" DataField="Status">
                            <ItemStyle HorizontalAlign="Center" Width="45px" Font-Bold="true" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Control">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="btnSave" ImageUrl="~/image/icon-save.png" ToolTip="Save" OnClick="btnSave_Click" Visible="false" Width="25px" Height="16px" />
                                <asp:ImageButton runat="server" ID="btnBack" ImageUrl="~/image/icon-return.png" ToolTip="Back" OnClick="btnBack_Click" Visible="false" Width="25px" Height="14px" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="30" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            <</asp:Panel>
        </div>
    </form>
</body>
</html>
