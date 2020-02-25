<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="container">

    <!-- Outer Row -->
    <div class="row justify-content-center">

      <div class="col-xl-10 col-lg-12 col-md-9"> 

       <div class="card o-hidden border-0 shadow-lg my-5">
          <div class="card-body p-0">
                <div class="p-5">
                  <div class="text-center">
                    <h1 class="h4 text-gray-900 mb-4">Welcome Back!</h1>
                  </div>
                  <div class="user">
                      <!-- change the label id: lblMessage. Change Text=""   -->
                      <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                    <div class="form-group">
                         <!-- change the textbox id: txtEmail. Change TextMode="Email"   -->
                        <asp:TextBox ID="txtEmail" runat="server"  placeholder="Enter Email Address..." class="form-control form-control-user" TextMode="Email"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <!-- change the textbox id: txtPassword. Change TextMode="Password"   -->
                         <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" class="form-control form-control-user" TextMode="Password" OnTextChanged="txtPassword_TextChanged"></asp:TextBox>
                    </div>
                      <!-- change the button id: BtnLogin. Change   Text="Login" --> 
                        <asp:Button ID="BtnLogin" runat="server" Text="Login" class="btn btn-primary btn-user btn-block" OnClick="BtnLogin_Click" />
                  </div>
                  <hr>
                  <div class="text-center">
                    <a class="small" href="ForgotPassword.aspx">Forgot Password?</a>
                  </div>
                  <div class="text-center">
                    <a class="small" href="Register.aspx">Create an Account!</a>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>

      </div>

</asp:Content>

