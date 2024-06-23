import { ApiService } from "./ApiService";

const BaseUrl = import.meta.env.VITE_API_URL;

const apiService = new ApiService(BaseUrl);

export { apiService };
