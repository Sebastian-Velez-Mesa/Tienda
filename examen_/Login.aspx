<%@ Page Title="Iniciar Sesion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="examen_.Login" %>
    <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class="centered-container">
            <div class="login-box">
                <div class="glass-card animate-fade-in" style="border-top: 4px solid var(--accent);">
                    <div class="text-center mb-5">
                        <i class="fas fa-user-lock"
                            style="font-size: 3.5rem; color: var(--accent); margin-bottom: 1rem;"></i>
                        <h2 style="color: white; font-weight: 700; letter-spacing: 1px;">ACCESO AL SISTEMA</h2>
                        <p class="text-secondary">Ingrese sus credenciales de seguridad</p>
                    </div>

                    <div class="form-group mb-4">
                        <label class="text-secondary small mb-2"><i class="fas fa-at me-2"></i>USUARIO</label>
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"
                            placeholder="Nombre de usuario"></asp:TextBox>
                    </div>

                    <div class="form-group mb-5">
                        <label class="text-secondary small mb-2"><i class="fas fa-key me-2"></i>CONTRASEÑA</label>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"
                            placeholder="••••••••"></asp:TextBox>
                    </div>

                    <asp:Button ID="btnLogin" runat="server" Text="INICIAR SESIÓN" CssClass="btn-premium w-100 py-3"
                        OnClick="btnLogin_Click" />

                    <asp:Label ID="lblMensaje" runat="server" CssClass="text-warning mt-4 d-block text-center small">
                    </asp:Label>

                    <div class="mt-5 pt-4 text-center" style="border-top: 1px solid var(--glass-border);">
                        <small class="text-muted">Desarrollado con Arquitectura N-Tier Premium</small>
                    </div>
                </div>

                <div class="text-center mt-4">
                    <span class="badge bg-dark text-secondary p-2" style="border: 1px solid var(--glass-border);">
                        <i class="fas fa-info-circle me-1"></i> Admin: admin/admin123 | Cliente: cliente/cliente123
                    </span>
                </div>
            </div>
        </div>
    </asp:Content>