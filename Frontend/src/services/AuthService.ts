import { useMsal } from "@azure/msal-react"

export const useAuth = () => {
  const { instance } = useMsal();

  const logOut = () => {
    instance.logoutPopup();
  };

  const logIn = () => {
    instance.loginPopup();
  };

  const getAccessToken = async () => {
    const request = {
      scopes: ["User.Read"],
    };

    const response = await instance.acquireTokenSilent(request);
    return response.accessToken;
  }

  return { logOut, logIn, getAccessToken };
};