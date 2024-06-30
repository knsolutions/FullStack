import axios, { AxiosInstance, AxiosResponse } from "axios";
import { IApiService } from "./IApiService";

export class ApiService implements IApiService {
  private api: AxiosInstance;

  constructor(baseURL: string) {
    this.api = axios.create({
      baseURL,
      timeout: 10000,
      headers: {
        "Content-Type": "application/json",
      },
    });
  }

  setAuthToken(token: string | null) {
    if (token) {
      this.api.defaults.headers.common["Authorization"] = `Bearer ${token}`;
    } else {
      delete this.api.defaults.headers.common["Authorization"];
    }
  }

  async get<T>(url: string, params: Record<string, any> = {}): Promise<T> {
    try {
      const response: AxiosResponse<T> = await this.api.get(url, { params });
      return response.data;
    } catch (error) {
      console.error("API call failed. Error:", error);
      throw error;
    }
  }

  async post<T, U>(url: string, data: U): Promise<T> {
    try {
      const response: AxiosResponse<T> = await this.api.post(url, data);
      return response.data;
    } catch (error) {
      console.error("API call failed. Error:", error);
      throw error;
    }
  }

  async put<T, U>(url: string, id: string | number, data: U): Promise<T> {
    try {
      const response: AxiosResponse<T> = await this.api.put(
        `${url}/${id}`,
        data
      );
      return response.data;
    } catch (error) {
      console.error("API call failed. Error:", error);
      throw error;
    }
  }

  async delete<T>(url: string, id: string | number): Promise<T> {
    try {
      const response: AxiosResponse<T> = await this.api.delete(`${url}/${id}`);
      return response.data;
    } catch (error) {
      console.error("API call failed. Error:", error);
      throw error;
    }
  }
}
