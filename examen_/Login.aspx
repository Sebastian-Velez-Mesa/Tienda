<%@ Page Title="Iniciar Sesion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="examen_.Login" %>
    <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class="row mt-5 fade-in-up">
            <div class="col-md-6 mx-auto">
                <div class="glass-card" style="padding: 2.5rem;">
                    <h2 class="text-center mb-4" style="color: #00d2ff; font-weight: 600;">Iniciar Sesion</h2>
                    <div class="form-group mb-4">
                        <label style="color:#e0e0e0; margin-bottom:0.5rem; display:block;">Usuario</label>
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"
                            placeholder="Ingrese su usuario"></asp:TextBox>
                    </div>
                    <div class="form-group mb-4">
                        <label style="color:#e0e0e0; margin-bottom:0.5rem; display:block;">Contrasena</label>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"
                            placeholder="Ingrese su contrasena"></asp:TextBox>
                    </div>
                    <div class="mt-4">
                        <asp:Button ID="btnLogin" runat="server" Text="Ingresar al Sistema"
                            CssClass="btn-primary-custom w-100 py-3" OnClick="btnLogin_Click" Font-Bold="True"
                            Font-Size="Large" />
                    </div>
                    <asp:Label ID="lblMensaje" runat="server" CssClass="text-warning mt-3 d-block text-center">
                    </asp:Label>
                </div>

                <div class="text-center mt-3 text-muted">
                    <small>Para probar, usa: admin/admin123 o cliente/cliente123</small>
                </div>
            </div>
        </div>
    </asp:Content>