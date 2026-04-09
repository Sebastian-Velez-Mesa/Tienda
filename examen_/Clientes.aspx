<%@ Page Title="Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Clientes.aspx.cs" Inherits="examen_.Clientes" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container mt-5 fade-in-up">
            <div class="glass-card">
                <h2>Gestion de Clientes</h2>
                <div class="row">
                    <div class="col-md-4">
                        <div class="form-group">
                            <label>Nombre:</label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group mt-3">
                            <label>Telefono:</label>
                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group mt-3">
                            <label>Email:</label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email">
                            </asp:TextBox>
                        </div>
                        <div class="form-group mt-3">
                            <label>Direccion:</label>
                            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mt-4">
                            <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cliente" OnClick="btnGuardar_Click"
                                CssClass="btn-primary-custom w-100" />
                        </div>
                        <asp:Label ID="lblMensaje" runat="server" CssClass="mt-3 d-block"></asp:Label>
                    </div>
                    <div class="col-md-8">
                        <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="false"
                            CssClass="table-custom mt-3" DataKeyNames="Id_Cliente" OnRowEditing="gvClientes_RowEditing"
                            OnRowDeleting="gvClientes_RowDeleting">
                            <Columns>
                                <asp:BoundField DataField="Id_Cliente" HeaderText="ID" ReadOnly="true" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                                <asp:BoundField DataField="Email" HeaderText="Email" />
                                <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
                                <asp:CommandField ShowEditButton="true" ShowDeleteButton="true"
                                    ControlStyle-CssClass="btn btn-sm btn-outline-info" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </asp:Content>