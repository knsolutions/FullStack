export interface IApiService {
  get<T>(url: string, params?: Record<string, any>): Promise<T>;
  post<T, U>(url: string, data: U): Promise<T>;
  put<T, U>(url: string, id: string | number, data: U): Promise<T>;
  delete<T>(url: string, id: string | number): Promise<T>;
}
