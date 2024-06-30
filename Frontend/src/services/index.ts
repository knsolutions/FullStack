import { ApiService } from "./ApiService";
import { API_BASE_URL } from "../config";  

const apiService = new ApiService(API_BASE_URL);

export { apiService };
