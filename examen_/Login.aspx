<%@ Page Title="Iniciar Sesion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="examen_.Login" %>
    <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class="centered-container">
            <div class="login-box animate-fade-in">
                <div class="glass-card" style="border-top: 5px solid var(--accent); padding: 3rem;">
                    <div class="text-center mb-5">
                        <div
                            style="width: 80px; height: 80px; background: rgba(0, 210, 255, 0.1); border-radius: 20px; display: flex; align-items: center; justify-content: center; margin: 0 auto 1.5rem auto; border: 1px solid var(--glass-border);">
                            <i class="fas fa-shield-alt" style="font-size: 2.5rem; color: var(--accent);"></i>
                        </div>
                        <h2 style="color: white; font-weight: 700; letter-spacing: 1px; font-size: 1.5rem;">BIENVENIDO
                        </h2>
                        <p class="text-secondary small">Panel de Gestión Administrativa</p>
                    </div>

                    <div class="form-group mb-4">
                        <label class="text-secondary small mb-2"
                            style="letter-spacing: 1px; font-weight: 600;">USUARIO</label>
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"
                            placeholder="Escriba su usuario"></asp:TextBox>
                    </div>

                    <div class="form-group mb-5">
                        <label class="text-secondary small mb-2"
                            style="letter-spacing: 1px; font-weight: 600;">CONTRASEÑA</label>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"
                            placeholder="••••••••"></asp:TextBox>
                    </div>

                    <asp:Button ID="btnLogin" runat="server" Text="Entrar al Portal" CssClass="btn-premium w-100 py-3"
                        OnClick="btnLogin_Click" />

                    <asp:Label ID="lblMensaje" runat="server" CssClass="text-warning mt-4 d-block text-center small">
                    </asp:Label>
                </div>

                <div class="text-center mt-5" style="opacity: 0.3;">
                    <small class="text-muted">Sistema de Seguridad de Capa Elite</small>
                </div>
            </div>
        </div>
    </asp:Content>